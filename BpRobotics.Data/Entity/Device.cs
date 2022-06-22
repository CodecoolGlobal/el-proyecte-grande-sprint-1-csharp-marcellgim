namespace BpRobotics.Data.Entity;

public class Device
{
    public int Id { get; set; }
    public string? Serial { get; set; }
    public Product Product { get; set; }
    public List<Service> Services { get; set; } = new();
    public DateTime LastMaintenance { get; set; }
    public DateTime NextMaintenance { get; set; }
    public DateTime WarrantyUntil { get; set; }
    public DeviceStatus Status { get; set; }
    public Customer Customer { get; set; }
    public Order Order { get; set; }
}