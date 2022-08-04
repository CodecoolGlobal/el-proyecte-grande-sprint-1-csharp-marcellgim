using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Model.ServiceDTOs;

public class ServiceViewDTO
{
    public int Id { get; set; }
    public PartnerViewDto? AssignedFor { get; set; }
    public DateTime RequestedDate { get; set; }
    public DateTime? DoneDate { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }

    public string Details { get; set; }

    public Device Device { get; set; }
}