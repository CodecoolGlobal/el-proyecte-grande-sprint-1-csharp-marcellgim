using BpRobotics.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpRobotics.Core.Model.Orders
{
    public class OrderCreateDTO
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public Dictionary<int, int> ProductIdsAndQuantity { get; set; }
    }
}
