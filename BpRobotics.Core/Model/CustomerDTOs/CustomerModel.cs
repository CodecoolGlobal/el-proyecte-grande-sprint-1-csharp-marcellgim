using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Model.CustomerDTOs
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public int VatNumber { get; set; }
        public Location? BillingAddress { get; set; }
        public Location? ShippingAddress { get; set; }
        public User? User { get; set; }
    }
}
