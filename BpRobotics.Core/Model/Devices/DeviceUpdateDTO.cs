using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpRobotics.Core.Model.Devices
{
    public class DeviceUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        public string? Serial { get; set; }
        public int? ProductId { get; set; }
        public string? LastMaintenance { get; set; }
        public string? NextMaintenance { get; set; }
        public string? WarrantyUntil { get; set; }
        public int? StatusNumber { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
    }
}
