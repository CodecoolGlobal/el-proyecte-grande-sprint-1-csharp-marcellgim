namespace BpRobotics.Data.Entity;

public class TicketComment
{
    public int Id { get; set; }
    public User CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
}