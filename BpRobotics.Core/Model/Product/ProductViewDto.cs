using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpRobotics.Core.Model.Product
{
    public class ProductViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageFileName { get; set; }
        public int ServiceInterval { get; set; }
        public int Warranty { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
    }
}
