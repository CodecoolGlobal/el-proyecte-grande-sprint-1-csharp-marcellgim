using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Model.ServiceDTOs;

public class ServiceCreateDTO
{
    public int? PartnerId;
    public string Type { get; set; }
}