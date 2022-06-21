namespace BpRobotics.Data.Entity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class Product
{
    
    public int Id { get; set; }
    public string Name { get; set; }

    public string Img => ProductImage?.FileName ?? "smart_ac.jpg";
    public int ServiceInterval { get; set; }
    public int Warranty { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public IFormFile? ProductImage { get; set; }
}