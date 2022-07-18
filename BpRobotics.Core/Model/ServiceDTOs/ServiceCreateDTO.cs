using System.ComponentModel.DataAnnotations;
using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Model.ServiceDTOs;

public class ServiceCreateDTO
{
    public int? PartnerId { get; set; }
    [Required]
    public string Type { get; set; }
}