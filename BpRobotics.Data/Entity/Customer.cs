﻿namespace BpRobotics.Data.Entity;

public class Customer
{
    public int Id { get; set; }
    public string CompanyName { get; set; } = String.Empty;
    public int VatNumber { get; set; }
    public Location BillingAddress { get; set; }
    public Location ShippingAddress { get; set; }
}