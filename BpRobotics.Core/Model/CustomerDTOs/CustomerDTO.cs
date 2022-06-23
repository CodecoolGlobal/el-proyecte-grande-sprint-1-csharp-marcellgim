using System.ComponentModel.DataAnnotations;

namespace BpRobotics.Core.Model.CustomerDTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public int VatNumber { get; set; }
    }
}
