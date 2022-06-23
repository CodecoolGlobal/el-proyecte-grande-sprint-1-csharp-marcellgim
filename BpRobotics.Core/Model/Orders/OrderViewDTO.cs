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
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public string CustomerCompanyName { get; set; }
        public string Address { get; set; }
        public Dictionary<string, int> Devices { get; set; }
    }
}
