using BpRobotics.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpRobotics.Core.Model.Orders
{
    public class OrderViewDTO
    {
        public DateTime Date { get; set; }
        public string CustomerCompanyName { get; set; }
        public string Address { get; set; }

        // eg. 3 Smart Air-condition, 2 Smart Fridge
        public Dictionary<string, int> OrderProducts { get; set; }
    }
}
