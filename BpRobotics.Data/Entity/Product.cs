namespace BpRobotics.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string? ImageFileName { get; set; }
    public int ServiceInterval { get; set; }
    public int Warranty { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }

    public bool IsDeleted { get; set; }
}