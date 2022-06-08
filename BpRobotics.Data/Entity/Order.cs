namespace BpRobotics.Data.Entity;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Customer Customer { get; set; }
    public Location Address { get; set; }
    public List<Device> Devices { get; set; } = new();
}