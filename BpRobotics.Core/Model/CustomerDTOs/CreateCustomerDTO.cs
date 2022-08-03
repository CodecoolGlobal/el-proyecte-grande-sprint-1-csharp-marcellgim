using System.ComponentModel.DataAnnotations;

namespace BpRobotics.Core.Model.CustomerDTOs
{
    public class CreateCustomerDto
    {
        private const int MinZipValue = 1000;
        private const int MaxZipValue = 9999;
        private const int MaxStringLength = 100;

        [Required]
        [StringLength(maximumLength: MaxStringLength)]
        public string CompanyName { get; set; }
        [Required]
        public int VatNumber { get; set; }
        [Required]
        [Range(minimum: MinZipValue, maximum: MaxZipValue)]
        public int BillingZip { get; set; }
        [Required]
        [StringLength(maximumLength: MaxStringLength)]
        public string BillingCountry { get; set; }
        [Required]
        [StringLength(maximumLength: MaxStringLength)]
        public string BillingCity { get; set; }
        [Required]
        [StringLength(maximumLength: MaxStringLength)]
        public string BillingAddress { get; set; }
        [Required]
        [Range(minimum: MinZipValue, maximum: MaxZipValue)]
        public int ShippingZip { get; set; }
        [Required]
        [StringLength(maximumLength: MaxStringLength)]
        public string ShippingCountry { get; set; }
        [Required]
        [StringLength(maximumLength: MaxStringLength)]
        public string ShippingCity { get; set; }
        [Required]
        [StringLength(maximumLength: MaxStringLength)]
        public string ShippingAddress { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
