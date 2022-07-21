namespace BpRobotics.Data.Entity;

public class Service
{
    public int Id { get; set; }
    public Device Device { get; set; }
    public Partner? Partner { get; set; }
    public DateTime RequestedDate { get; set; }
    public DateTime? DoneDate { get; set; }
    public ServiceType Type { get; set; }
    public ServiceStatus Status { get; set; }
}