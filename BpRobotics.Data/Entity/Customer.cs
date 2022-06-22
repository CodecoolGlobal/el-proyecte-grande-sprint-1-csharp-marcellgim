namespace BpRobotics.Data.Entity;

public class Customer
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public int VatNumber { get; set; }
    public Location? BillingAddress { get; set; }
    public Location? ShippingAddress { get; set; }
    public User? User { get; set; }
}