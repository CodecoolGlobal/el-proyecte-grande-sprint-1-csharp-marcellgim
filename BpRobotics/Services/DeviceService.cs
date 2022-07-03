using BpRobotics.Core.Extensions;
using BpRobotics.Core.Model.Devices;
using BpRobotics.Core.Model.ServiceDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;

namespace BpRobotics.Services;

public class DeviceService
{
    private readonly IRepository<Device> _deviceRepository;
    private readonly IRepository<Partner> _partnerRepository;
    private readonly IRepository<Service> _serviceRepository;

    public DeviceService(IRepository<Service> serviceRepository, IRepository<Device> deviceRepository, IRepository<Partner> partnerRepository)
    {
        _deviceRepository = deviceRepository;
        _partnerRepository = partnerRepository;
        _serviceRepository = serviceRepository;
    }

    public async Task<DeviceViewDTO> GetById(int deviceId)
    {
        return (await _deviceRepository.Get(deviceId)).ToDeviceView();
    }

    public async Task<ServiceViewDTO> GetService(int serviceId)
    {
        return (await _serviceRepository.Get(serviceId)).ToServiceView();
    }

    public async Task<ServiceViewDTO> AddServiceToDevice(int deviceId, ServiceCreateDTO service)
    {
        var device = await _deviceRepository.Get(deviceId);
        Partner? partner = (service.PartnerId != null) ? await _partnerRepository.Get((int)service.PartnerId) : null;
        
        var serviceEntity = service.ToServiceEntity();
        serviceEntity.Device = device;
        serviceEntity.AssignedFor = partner;

        await _serviceRepository.Add(serviceEntity);
        return serviceEntity.ToServiceView();
    }
}