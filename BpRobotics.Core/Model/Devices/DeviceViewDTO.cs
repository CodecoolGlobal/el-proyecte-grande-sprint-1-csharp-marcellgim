using BpRobotics.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BpRobotics.Core.Model.ServiceDTOs;

namespace BpRobotics.Core.Model.Devices
{
    public class DeviceViewDTO
    {
        public string? Serial { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string LastMaintenance { get; set; }
        public string NextMaintenance { get; set; }
        public string WarrantyUntil { get; set; }
        public string Status { get; set; }
        public List<ServiceViewDTO> Services { get; set; }
        public int CustomerId { get; set; }
        public string CustomerCompanyName { get; set; }
        public int OrderId { get; set; }
    }
}
