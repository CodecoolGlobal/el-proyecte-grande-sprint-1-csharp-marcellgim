using System.ComponentModel.DataAnnotations;

namespace BpRobotics.Core.Model.CustomerDTOs
{
    public class CustomerUpdateDto
    {
        private const int MinZipValue = 1000;
        private const int MaxZipValue = 9999;
        private const int MaxStringLength = 100;
        
        [Required]
        public int Id { get; set; }
        [StringLength(maximumLength:MaxStringLength)]
        public string? CompanyName { get; set; }
        public int VatNumber { get; set; }
        [Range(minimum: MinZipValue, maximum: MaxZipValue)]
        public int BillingZip { get; set; }
        [Required]
        public int BillingLocationId { get; set; }
        [StringLength(maximumLength:MaxStringLength)]
        public string? BillingCountry { get; set; }
        [StringLength(maximumLength:MaxStringLength)]
        public string? BillingCity { get; set; }
        [StringLength(maximumLength:MaxStringLength)]
        public string? BillingAddress { get; set; }
        [Required]
        public int ShippingLocationId { get; set; }
        [Range(minimum: MinZipValue, maximum: MaxZipValue)]
        public int ShippingZip { get; set; }
        [StringLength(maximumLength:MaxStringLength)]
        public string? ShippingCountry { get; set; }
        [StringLength(maximumLength:MaxStringLength)]
        public string? ShippingCity { get; set; }
        [StringLength(maximumLength:MaxStringLength)]
        public string? ShippingAddress { get; set; }
    }
}
