using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    public class Baker
    {
        private static int currentId = 1;

        public int index { get; }
        public int workExperience { get; }

        public List<int> orders { get; }

        public enum BakerStatus
        {
            Ready,
            Waiting,
            Cooking
        }

        public BakerStatus status { get; private set; }

        public Baker(int workExperience)
        {
            index = currentId++;
            status = BakerStatus.Ready;
            orders = new List<int>();
            this.workExperience = workExperience;
        }

        public bool AssignOrder(int orderIndex)
        {
            if (orders.Count == CalculateMaxNumOrders()) return false;
            orders.Add(orderIndex);
            return true;
        }

        public void CompleteOrders()
        {
            orders.Clear();
            UpdateStatus(BakerStatus.Ready);
        }

        public void CompleteOrders(List<int> ordersIndcies)
        {
            orders.RemoveAll(r => ordersIndcies.Contains(r));
            if (orders.Count == 0) UpdateStatus(BakerStatus.Ready);
        }

        //public void CompleteOrder(int orderIndex)
        //{
        //    orders.Remove(orderIndex);
        //    if (orders.Count == 0) UpdateStatus(BakerStatus.Ready);
        //}

        public void UpdateStatus(BakerStatus newStatus)
        {
            status = newStatus;
            if (status == BakerStatus.Ready) orders.Clear();
        }

        public int CalculateMaxNumOrders()
        {
            if (workExperience < 5) return 1;
            else if (workExperience < 10) return 2;
            else return 3;
        }

        public bool IsFull() => orders.Count == CalculateMaxNumOrders();
    }
}
