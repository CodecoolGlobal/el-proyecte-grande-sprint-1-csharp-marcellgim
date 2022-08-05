namespace BpRobotics.Data.Entity;

public class Partner : ISoftDelete
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string PhoneNumber { get; set; }
    public User? User { get; set; }
    public List<Service> Services { get; set; }
    public bool IsDeleted { get; set; }

    public int? UserId { get; set; }

}