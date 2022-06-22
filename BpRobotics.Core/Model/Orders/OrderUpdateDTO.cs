using BpRobotics.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpRobotics.Core.Model.Orders
{
    public class OrderUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SelectedCustomerId { get; set; }
        public int SelectedLoactionId { get; set; }
        public List<int> SelectedDeviceIds { get; set; }
    }
}
