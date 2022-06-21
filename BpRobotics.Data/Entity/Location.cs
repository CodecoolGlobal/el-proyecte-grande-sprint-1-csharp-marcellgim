namespace BpRobotics.Data.Entity;

public class Location
{
    public int Id { get; set; }
    public int ZIP { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Address { get; set; }

    public virtual Customer? Customer { get; set; }
}