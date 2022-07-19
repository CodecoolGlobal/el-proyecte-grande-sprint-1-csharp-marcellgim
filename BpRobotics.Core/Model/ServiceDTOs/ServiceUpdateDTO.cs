using System.ComponentModel.DataAnnotations;

namespace BpRobotics.Core.Model.ServiceDTOs;

public class ServiceUpdateDTO
{
    [Required]
    public int Id { get; set; }
    public int? PartnerId { get; set; }
    public DateTime? DoneDate { get; set; }
    [Required]
    public string Status { get; set; }
}