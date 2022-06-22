using System.ComponentModel.DataAnnotations;

namespace BpRobotics.Core.Model.CustomerDTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public int VatNumber { get; set; }
    }
}
