using System.Data;

namespace Pizza
{
    class Program
    {
        static void Main() {
            int warehouseCapacity = 5;

            Pizzeria myPizzeria = new Pizzeria(warehouseCapacity);
            myPizzeria.LoadWorkersFromJsonFile("Workers.json");
            

            bool finishWork = false;
            while (!finishWork)
            {
                Console.WriteLine("Выберите операцию\n" +
                    "1) Создать новый заказ\n" +
                    "2) Завершить работу пекаря i\n" +
                    "3) Завершить работу курьера i\n"+
                    "4) Завершить смену");

                string method = Console.ReadLine();
                switch (method)
                {
                    case "1":
                        myPizzeria.CreateOrder();
                       // myPizzeria.automationSystem.MakeRecomendation();
                       foreach(Order order in myPizzeria.orders.Values){
                         Console.WriteLine("Заказ - {0}", order.index);
                         Console.WriteLine("Заказ - {0}", order.status);
                       }
                        
                        break;
                    case "2":
                        List<int> bakersCooking = myPizzeria.GetBakersCooking();
                        if (bakersCooking.Count != 0)
                        {
                            Console.WriteLine("Выберете пекаря");
                            foreach(int baker in bakersCooking)
                            {
                                Console.WriteLine("Пекарь - {0}", baker);
                            }

                            int indexBaker = int.Parse(Console.ReadLine());
                            while (!bakersCooking.Contains(indexBaker))
                            {
                                Console.WriteLine("Выберете пекаря из предложенных");
                                indexBaker = int.Parse(Console.ReadLine());
                            }

                            myPizzeria.CompleteBakerOrders(indexBaker);
                        
                            break;
                        }
                         foreach(Order order in myPizzeria.orders.Values){
                         Console.WriteLine("Заказ - {0}", order.index);
                         Console.WriteLine("Заказ - {0}", order.status);
                       }
                        
                        Console.WriteLine("Нет пекарей в работе");
                        break;
                    case "3":
                        List<int> couriersDelivers = myPizzeria.GetCouriersDelivers();
                        if (couriersDelivers.Count != 0)
                        {
                            Console.WriteLine("Выберете курьера");
                            foreach (int courier in couriersDelivers)
                            {
                                Console.WriteLine("Курьер - {0}", courier);
                            }

                            int indexCourier = int.Parse(Console.ReadLine());
                            while (!couriersDelivers.Contains(indexCourier))
                            {
                                Console.WriteLine("Выберете курьера из предложенных");
                                indexCourier = int.Parse(Console.ReadLine());
                            }

                            myPizzeria.CompleteCourierOrders(indexCourier);
                            break;
                        }
                        foreach(Order order in myPizzeria.orders.Values){
                         Console.WriteLine("Заказ - {0}", order.index);
                         Console.WriteLine("Заказ - {0}", order.status);
                       }
                        Console.WriteLine("Нет курьеров в работе");
                        break;
                    case "4":
                        myPizzeria.FinishWork();
                        finishWork = true;
                        break;
                }
            }
        }
    }
}
