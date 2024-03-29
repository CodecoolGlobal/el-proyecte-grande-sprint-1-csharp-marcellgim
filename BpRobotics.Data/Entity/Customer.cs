﻿namespace BpRobotics.Data.Entity;

public class Customer : ISoftDelete
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public int VatNumber { get; set; }
    public Location BillingAddress { get; set; }
    public Location ShippingAddress { get; set; }
    public User? User { get; set; }
    public bool IsDeleted { get; set; }

}