using BpRobotics.Core.Model.Devices;
using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Extensions
{
    public static class DeviceExtensions
    {
        public static DeviceViewDTO ToDeviceView(this Device device)
        {
            return new DeviceViewDTO
            {
                Id = device.Id,
                Serial = device.Serial,
                ProductName = device.Product.Name,
                LastMaintenance = device.LastMaintenance.ToString(),
                NextMaintenance = device.NextMaintenance.ToString(),
                WarrantyUntil = device.WarrantyUntil.ToString(),
                Services = device.Services.Select(s => s.ToServiceView()).ToList(),
                Status = device.Status.ToString(),
                OrderId = device.Order.Id
            };
        }

        public static Device ToDeviceEntity(this DeviceCreateDTO deviceCreate)
        {
            return new Device
            {
                Serial = deviceCreate.Serial,
                Status = DeviceStatus.InstallPending,
            };
        }

        public static Device ToDeviceEntity(this DeviceUpdateDTO deviceUpdate, Device deviceToUpdate)
        {
            deviceToUpdate.Serial = deviceUpdate.Serial ?? deviceToUpdate.Serial;
            deviceToUpdate.LastMaintenance = (deviceUpdate.LastMaintenance != null) ? DateTime.Parse(deviceUpdate.LastMaintenance) : deviceToUpdate.LastMaintenance;
            deviceToUpdate.NextMaintenance = (deviceUpdate.NextMaintenance != null) ? DateTime.Parse(deviceUpdate.NextMaintenance) : deviceToUpdate.NextMaintenance;
            deviceToUpdate.WarrantyUntil = (deviceUpdate.WarrantyUntil != null) ? DateTime.Parse(deviceUpdate.WarrantyUntil) : deviceToUpdate.WarrantyUntil;
            deviceToUpdate.Status = (deviceUpdate.StatusNumber != null) ? (DeviceStatus)deviceUpdate.StatusNumber : deviceToUpdate.Status;

            return deviceToUpdate;
        }
    }
}
