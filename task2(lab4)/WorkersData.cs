using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza
{
    public class WorkersData
    {
        public List<Baker> bakers { get; set; }
        public List<Courier> couriers { get; set; }

        public WorkersData(List<Baker> bakers, List<Courier> couriers)
        {
            this.bakers = bakers;
            this.couriers = couriers;
        }
    }
}
