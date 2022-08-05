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

    public async Task<List<DeviceViewDTO>> GetDevices()
    {
        return (await _deviceRepository.GetAll()).Select(d => d.ToDeviceView()).ToList();
    }

    public async Task<List<DeviceViewDTO>> GetDevices(int customerId)
    {
        return (await _deviceRepository.GetAll())
            .Where(device => device.Order.Customer.Id == customerId)
            .Select(device => device.ToDeviceView())
            .ToList();
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
        Partner? partner = service.PartnerId != null ? await _partnerRepository.Get((int)service.PartnerId) : null;
        
        var serviceEntity = service.ToServiceEntity();
        serviceEntity.Device = device;
        serviceEntity.Partner = partner;

        await _serviceRepository.Add(serviceEntity);
        return serviceEntity.ToServiceView();
    }

    public async Task RemoveService(int serviceId)
    {
        await _serviceRepository.Delete(serviceId);
    }

    public async Task<ServiceViewDTO> UpdateService(ServiceUpdateDTO updatedService)
    {
        var serviceToUpdate = await _serviceRepository.Get(updatedService.Id);
        if (updatedService.PartnerId != null)
        {
            var partner = await _partnerRepository.Get((int)updatedService.PartnerId);
            serviceToUpdate.Partner = partner;
        }

        if (updatedService.DoneDate != null)
        {
            serviceToUpdate.DoneDate = (DateTime)updatedService.DoneDate;
        }

        serviceToUpdate.Status = Enum.Parse<ServiceStatus>(updatedService.Status);

        return (await _serviceRepository.Update(serviceToUpdate)).ToServiceView();
    }

    public async Task UpdateSerial(int deviceId, string newSerial)
    {
        var deviceToUpdate = await _deviceRepository.Get(deviceId);
        deviceToUpdate.Serial = newSerial;
        await _deviceRepository.Update(deviceToUpdate);
    }
}