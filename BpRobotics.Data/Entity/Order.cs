namespace BpRobotics.Data.Entity;

public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public Customer Customer { get; set; }
    public List<Device> Devices { get; set; } = new();
    public bool IsDeleted { get; set; }

}