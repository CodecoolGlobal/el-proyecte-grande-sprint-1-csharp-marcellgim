using BpRobotics.Core.Extensions;
using BpRobotics.Core.Model.Devices;
using BpRobotics.Core.Model.ServiceDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;

namespace BpRobotics.Services;

public class ServiceService
{
    private readonly IRepository<Device> _deviceRepository;
    private readonly IRepository<Partner> _partnerRepository;
    private readonly IRepository<Service> _serviceRepository;

    public ServiceService(IRepository<Service> serviceRepository, IRepository<Device> deviceRepository, IRepository<Partner> partnerRepository)
    {
        _deviceRepository = deviceRepository;
        _partnerRepository = partnerRepository;
        _serviceRepository = serviceRepository;
    }

    public async Task<List<ServiceViewDTO>> GetServices()
    {
        return (await _serviceRepository.GetAll())
            .Select(service => service.ToServiceView())
            .ToList();
    }

    public async Task<List<ServiceViewDTO>> GetServices(int partnerId)
    {
        return (await _serviceRepository.GetAll())
            .Select(service=>service.ToServiceView())
            .Where(service=>service.AssignedFor?.Id==partnerId).ToList();
    }

    public async Task StartService(int serviceId)
    {
        var serviceToUpdate = await _serviceRepository.Get(serviceId);

        serviceToUpdate.Status = ServiceStatus.InProgress;

        await _serviceRepository.Update(serviceToUpdate);
    }

    public async Task FinishService(int serviceId)
    {
        var serviceToUpdate = await _serviceRepository.Get(serviceId);

        serviceToUpdate.DoneDate = DateTime.Today;

        serviceToUpdate.Status = ServiceStatus.Done;
        var device = serviceToUpdate.Device;

        if (serviceToUpdate.Type == ServiceType.Install)
        {
            device.WarrantyUntil = DateTime.Today.AddDays(device.Product.Warranty);
            device.NextMaintenance = DateTime.Today.AddDays(device.Product.ServiceInterval);
            device.Status = DeviceStatus.UpToDate;
            await _deviceRepository.Update(device);
        }
        else if (serviceToUpdate.Type == ServiceType.Maintenance)
        {
            device.LastMaintenance = DateTime.Today;
            device.NextMaintenance = DateTime.Today.AddDays(device.Product.ServiceInterval);
            if (device.Status!=DeviceStatus.WarrantyExpired)
            {
                device.Status = DeviceStatus.UpToDate;
            }
            await _deviceRepository.Update(device);
        }

        await _serviceRepository.Update(serviceToUpdate);
    }
}