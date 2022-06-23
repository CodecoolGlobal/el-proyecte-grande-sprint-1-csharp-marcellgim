using System.ComponentModel.DataAnnotations.Schema;

namespace BpRobotics.Data.Entity;

[ComplexType]
public class Location
{
    public int ZIP { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }

    public override string ToString()
    {
        return $"{ZIP} {Country} {City} {Address}";
    }
}