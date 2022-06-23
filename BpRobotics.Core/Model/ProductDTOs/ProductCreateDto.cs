using System.ComponentModel.DataAnnotations;

namespace BpRobotics.Core.Model.ProductDTOs
{
    public class ProductCreateDto
    {
        [Required(ErrorMessage = "Product name is required")]
        public string Name { get; set; }
        public string? ImageFileName { get; set; }
        [Required(ErrorMessage = "Service interval is required")]
        [Range(0, 365, ErrorMessage = "The value must be between 0 and 365")]
        public int ServiceInterval { get; set; }
        [Required(ErrorMessage = "Warranty is required")]
        [Range(0, 3650, ErrorMessage = "The value must be between 0 and 3650")]
        public int Warranty { get; set; }
        [Required(ErrorMessage = "Short description is required")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Long description is required")]
        public string LongDescription { get; set; }
    }
}
