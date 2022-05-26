namespace BpRobotics.Data.Model;

public class Customer
{
    public string CompanyName { get; set; } = String.Empty;
    public int VatNumber { get; set; }
    public Location BillingAddress { get; set; }
    public Location ShippingAddress { get; set; }
}