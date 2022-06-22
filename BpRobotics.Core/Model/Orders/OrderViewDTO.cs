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
        public Customer Customer { get; set; }
        public Location Address { get; set; }
        public List<Device> Devices { get; set; }
    }
}
