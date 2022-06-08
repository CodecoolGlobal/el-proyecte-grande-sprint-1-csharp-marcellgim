namespace BpRobotics.Data.Entity;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TimeSpan ServiceInterval { get; set; }
    public int Warranty { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
}