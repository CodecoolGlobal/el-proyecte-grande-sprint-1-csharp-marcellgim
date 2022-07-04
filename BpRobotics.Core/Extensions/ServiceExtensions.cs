using BpRobotics.Core.Model.ServiceDTOs;
using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Extensions;

public static class ServiceExtensions
{
    public static Service ToServiceEntity(this ServiceCreateDTO serviceCreateData)
    {
        var serviceType = Enum.Parse<ServiceType>(serviceCreateData.Type);
        return new Service
        {
            RequestedDate = DateTime.Now,
            Status = ServiceStatus.Planned,
            Type = serviceType
        };
    }

    public static ServiceViewDTO ToServiceView(this Service serviceEntity)
    {
        return new ServiceViewDTO
        {
            Id = serviceEntity.Id,
            AssignedFor = serviceEntity.Partner?.ToPartnerViewDto(),
            RequestedDate = serviceEntity.RequestedDate,
            DoneDate = serviceEntity.DoneDate,
            Status = serviceEntity.Status.ToString(),
            Type = serviceEntity.Type.ToString()
        };
    }
}