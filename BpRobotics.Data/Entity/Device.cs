namespace BpRobotics.Data.Entity;

public class Device
{
    public int Id { get; set; }
    public string? Serial { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public DateTime? LastMaintenance { get; set; }
    public DateTime? NextMaintenance { get; set; }
    public DateTime? WarrantyUntil { get; set; }
    public DeviceStatus Status { get; set; }
    public Order Order { get; set; }
}