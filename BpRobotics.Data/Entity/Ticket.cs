namespace BpRobotics.Data.Model;

public class Ticket
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public User CreatedBy { get; set; }
    public List<Device>? Devices { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TicketStatus Status { get; set; }
    public Priority Priority { get; set; }
    public User? AssignedFor { get; set; }
    public List<TicketComment> Comments { get; set; } = new();
}