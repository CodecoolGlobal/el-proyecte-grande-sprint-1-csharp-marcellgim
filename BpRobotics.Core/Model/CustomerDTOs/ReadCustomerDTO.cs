using System.ComponentModel.DataAnnotations;

namespace BpRobotics.Core.Model.CustomerDTOs
{
    public class ReadCustomerDTO
    {
        private const int MinZipValue = 1000;
        private const int MaxZipValue = 9999;
        private const int MaxStringLength = 100;
        
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public int VatNumber { get; set; }
        public int BillingZIP { get; set; }
        public string BillingCountry { get; set; }
        public string BillingCity { get; set; }
        public string BillingAddress { get; set; }
        public int ShippingZIP { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingAddress { get; set; }
    }
}
