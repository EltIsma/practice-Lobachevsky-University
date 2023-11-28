using Pizza;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Pizza.Baker;

namespace Pizza
{
    public class Pizzeria
    {
        public Dictionary<int, Order> orders { get; set; }
        public Dictionary<int, Baker> bakerDictionary { get; set; }
        public Dictionary<int, Courier> courierDictionary { get; set; }
        public Warehouse warehouse { get; set; }
        public AutomationSystem automationSystem { get; set; }

        public Pizzeria(int warehouseCapacity)
        {
            orders = new Dictionary<int, Order>();
            bakerDictionary = new Dictionary<int, Baker>();
            courierDictionary = new Dictionary<int, Courier>();
            warehouse = new Warehouse(warehouseCapacity);
            automationSystem = new AutomationSystem();
        }

        //public Pizzeria(List<Baker> bakerList, List<Courier> courierList, int warehouseCapacity)
        //{
        //    orders = new Dictionary<int, Order>();

        //    bakerDictionary = new Dictionary<int, Baker>();
        //    foreach(Baker bakerToAdd in bakerList)
        //    {
        //        bakerDictionary.Add(bakerToAdd.index, bakerToAdd);
        //    }

        //    courierDictionary = new Dictionary<int, Courier>();
        //    foreach (Courier courierToAdd in courierList)
        //    {
        //        courierDictionary.Add(courierToAdd.index, courierToAdd);
        //    }

        //    warehouse = new Warehouse(warehouseCapacity);
        //}

        public void LoadWorkersFromJsonFile(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                WorkersData workersData = JsonSerializer.Deserialize<WorkersData>(json);

                foreach (Baker bakerToAdd in workersData.bakers)
                {
                    bakerDictionary.Add(bakerToAdd.index, bakerToAdd);
                }

                foreach (Courier courierToAdd in workersData.couriers)
                {
                    courierDictionary.Add(courierToAdd.index, courierToAdd);
                }
            }
        }

        public List<int> GetBakersCooking()
        {
            List<int> bakers = new List<int>();

            foreach (Baker curBaker in bakerDictionary.Values)
            {
                if (curBaker.status == Baker.BakerStatus.Cooking)
                {
                    bakers.Add(curBaker.index);
                }
            }

            return bakers;
        }

        public List<int> GetCouriersDelivers()
        {
            List<int> couriers = new List<int>();

            foreach (Courier curCourier in courierDictionary.Values)
            {
                if (curCourier.status == Courier.CourierStatus.Delivers)
                {
                    couriers.Add(curCourier.index);
                }
            }

            return couriers;
        }

        public int? FindOrderInWarehouse(int maxSize)
        {
            int order = warehouse.orders.FirstOrDefault(x => orders[x].size <= maxSize);
            if (order == 0) return null;
            return order;
        }

        public int? FindWaitingBaker()
        {
            Baker baker = bakerDictionary.Values.FirstOrDefault(x => x.status == Baker.BakerStatus.Waiting);
            if (baker == null) return null;
            return baker.index;
        }

        public int? FindFreeCourier()
        {
            Courier courier = courierDictionary.Values.FirstOrDefault(x => x.status == Courier.CourierStatus.Ready);
            if (courier == null) return null;
            return courier.index;
        }

        public int? FindOrderWaitingBaker()
        {
            Order order = orders.Values.FirstOrDefault(x => x.status == Order.OrderStatus.WaitingBaker);
            if (order == null) return null;
            return order.index;
        }

        public int? FindFreeBaker()
        {
            Baker baker = bakerDictionary.Values.FirstOrDefault(x => x.status == Baker.BakerStatus.Ready);
            if (baker == null) return null;
            return baker.index;
        }

        public int? FindNotFullBaker()
        {
            Baker baker = bakerDictionary.Values.FirstOrDefault(x => !x.IsFull());
            if (baker == null) return null;
            return baker.index;
        }

        public List<int> CreateOrdersQueueToAssignCourier(int trunkSize)
        {
            List<int> ordersToCourier = new List<int>();
            int? orderToAssign = FindOrderInWarehouse(trunkSize);
            while (orderToAssign.HasValue)
            {
                ordersToCourier.Add(orderToAssign.Value);
                trunkSize -= orders[orderToAssign.Value].size;
                orderToAssign = FindOrderInWarehouse(trunkSize);
            }
            return ordersToCourier;
        }

        public List<Order> AssignOrdersToCourierFromQueue(int indexCourier)
        {
            List<int> ordersToCourier = CreateOrdersQueueToAssignCourier(courierDictionary[indexCourier].trunkSize);
            return AssignOrdersToCourier(indexCourier, ordersToCourier);
        }

        public void CompleteCourierOrders(int indexCourier)
        {
            if (courierDictionary.ContainsKey(indexCourier))
            {
                if (courierDictionary[indexCourier].status == Courier.CourierStatus.Delivers)
                {

                    foreach(int orderToComplete in courierDictionary[indexCourier].orders)
                    {
                        orders.Remove(orderToComplete);
                    }
                    courierDictionary[indexCourier].CompleteOrders();

                    List<Order> ordersToRemoveFromWarehouse = AssignOrdersToCourierFromQueue(indexCourier);
                    if (ordersToRemoveFromWarehouse.Count > 0)
                    {
                        warehouse.RemoveOrders(ordersToRemoveFromWarehouse);
                        SendOrdersToWarehouseFromQueue();
                    }
                }
                else Console.WriteLine("Данному курьеру ещё не был назначен заказ");
            }
            else Console.WriteLine("В функцию был передан несуществующий курьер");
        }

        public List<Order> AssignOrdersToCourier(int indexCourier, List<int> ordersToAssign)
        {
            List<Order> assignedOrders = new List<Order>();
            foreach (int orderToAdd in ordersToAssign)
            {
                if (courierDictionary[indexCourier].AssignOrder(orderToAdd, orders[orderToAdd].size))
                {
                    orders[orderToAdd].UpdateStatus(Order.OrderStatus.Courier);
                    assignedOrders.Add(orders[orderToAdd]);
                }
            }
            if (assignedOrders.Count != 0) courierDictionary[indexCourier].UpdateStatus(Courier.CourierStatus.Delivers);
            return assignedOrders;
        }

        public void SendOrdersToWarehouseFromQueue()
        {
            int? indexWaitingBaker = FindWaitingBaker();
            if (indexWaitingBaker != null) CompleteBakerOrders(indexWaitingBaker.Value);
        }

        public bool SendOrderToWarehouse(int indexBaker)
        {
            List<int> ordersToCourier = new List<int>();

            foreach (int orderToAssign in bakerDictionary[indexBaker].orders)
            {
                if (warehouse.currentCapacity + orders[orderToAssign].size > warehouse.maxСapacity) break;

                warehouse.SetOrder(orders[orderToAssign]);
                orders[orderToAssign].UpdateStatus(Order.OrderStatus.Warehouse);

                ordersToCourier.Add(orderToAssign);
            }

            bakerDictionary[indexBaker].CompleteOrders(ordersToCourier);

            if (ordersToCourier.Count == 0) return false;

            int? indexFreeCourier = FindFreeCourier();
            if (indexFreeCourier.HasValue)
            {
                List<Order> ordersToRemove = AssignOrdersToCourier(indexFreeCourier.Value, ordersToCourier);
                if (ordersToRemove.Count > 0)
                {
                    warehouse.RemoveOrders(ordersToRemove);
                    SendOrdersToWarehouseFromQueue();
                }
            }
            else automationSystem.SendReportCouriers();
               
            if (bakerDictionary[indexBaker].status == Baker.BakerStatus.Ready) return true;
            return false;
        }

        public List<int> CreateOrdersQueueToAssignBaker(int indexBaker)
        {
            List<int> ordersToBaker = new List<int>();
            for (int i = 0; i < bakerDictionary[indexBaker].CalculateMaxNumOrders(); i++)
            {
                int? orderToAssign = FindOrderWaitingBaker();
                if (orderToAssign == null) break;
                ordersToBaker.Add(orderToAssign.Value);
                //Console.WriteLine("Очеред заказов ожидающих пекаря")

            }
           // foreach()
            return ordersToBaker;
        }

        public void AssignOrdersToBakerFromQueue(int indexBaker)
        {
            List<int> ordersToBaker = CreateOrdersQueueToAssignBaker(indexBaker);
        
            if (ordersToBaker.Count > 0) AssignOrdersToBaker(indexBaker, ordersToBaker);
        }

        public void CompleteBakerOrders(int indexBaker)
        {
            if (bakerDictionary.ContainsKey(indexBaker))
            {
                if (bakerDictionary[indexBaker].status != Baker.BakerStatus.Ready)
                {
                    bakerDictionary[indexBaker].UpdateStatus(Baker.BakerStatus.Waiting);
                    if (SendOrderToWarehouse(indexBaker)) AssignOrdersToBakerFromQueue(indexBaker);
                    else automationSystem.SendReportWarehouse();
                }
                else Console.WriteLine("Данному пекарю ещё не был назначен заказ");
            }
            else Console.WriteLine("В функцию был передан несуществующий пекарь");
        }

        public void AssignOrdersToBaker(int indexBaker, List<int> ordersToAssign)
        {
            if (bakerDictionary.ContainsKey(indexBaker))
            {
                foreach (int orderToAdd in ordersToAssign)
                {
                    if (!bakerDictionary[indexBaker].AssignOrder(orderToAdd)) return;
                    orders[orderToAdd].UpdateStatus(Order.OrderStatus.Baker);
                    if (bakerDictionary[indexBaker].status != Baker.BakerStatus.Cooking) bakerDictionary[indexBaker].UpdateStatus(Baker.BakerStatus.Cooking);
                }
                return;
            }
            Console.WriteLine("В функцию был передан несуществующий пекарь");
        }

        public int CreateOrder(int sizeOrder = 1)
        {
            Order newOrder = new Order(sizeOrder);
            orders.Add(newOrder.index, newOrder);

            int? indexFreeBaker = FindFreeBaker();
            if (indexFreeBaker.HasValue) {AssignOrdersToBaker(indexFreeBaker.Value, new List<int> { newOrder.index });

            Console.WriteLine("Пекарю с индексом {0} назначен заказ с номером {1}", indexFreeBaker.Value, newOrder.index);
            }
            else
            {
                indexFreeBaker = FindNotFullBaker();
                if (indexFreeBaker.HasValue) {AssignOrdersToBaker(indexFreeBaker.Value, new List<int> { newOrder.index });
            Console.WriteLine("Пекарю с индексом {0} назначен заказ с номером {1}", indexFreeBaker.Value, newOrder.index);
                }
                else if (!warehouse.IsFull()) automationSystem.SendReportBakers();
            }

            return newOrder.index;
        }

        public void FinishWork()
        {
            foreach(Baker baker in bakerDictionary.Values) baker.CompleteOrders();
            foreach(Courier courier in courierDictionary.Values) courier.CompleteOrders();
            orders.Clear();
            warehouse.RemoveOrders();

            automationSystem.MakeRecomendation();
        }
    }
}
