using BpRobotics.Core.Model.Devices;
using BpRobotics.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpRobotics.Core.Extensions
{
    public static class DeviceExtensions
    {
        public static DeviceViewDTO ToDeviceView(this Device device)
        {
            return new DeviceViewDTO
            {
                Serial = device.Serial,
                ProductName = device.Product.Name,
                LastMaintenance = device.LastMaintenance.ToString(),
                NextMaintenance = device.NextMaintenance.ToString(),
                WarrantyUntil = device.WarrantyUntil.ToString(),
                Status = device.Status,
                CustomerCompanyName = device.Customer.CompanyName,
                OrderId = device.Order.Id
            };
        }

        public static Device ToDeviceEntity(this DeviceViewDTO deviceView)
        {
            return new Device
            {
                Serial = deviceView.Serial,
                ProductId = deviceView.ProductId,
                LastMaintenance = DateTime.Parse(deviceView.LastMaintenance),
                NextMaintenance = DateTime.Parse(deviceView.NextMaintenance),
                WarrantyUntil = DateTime.Parse(deviceView.WarrantyUntil),
                Status = deviceView.Status,
                CustomerId = deviceView.CustomerId,
                OrderId = deviceView.OrderId
            };
        }

        public static Device ToDeviceEntity(this DeviceCreateDTO deviceCreate)
        {
            return new Device
            {
                Serial = deviceCreate.Serial,
                ProductId = deviceCreate.ProductId,
                Status = DeviceStatus.InstallPending,
                CustomerId = deviceCreate.CustomerId,
                OrderId = deviceCreate.OrderId
            };
        }

        public static Device ToDeviceEntity(this DeviceUpdateDTO deviceUpdate, Device deviceToUpdate)
        {
            deviceToUpdate.Serial = deviceUpdate.Serial ?? deviceToUpdate.Serial;
            deviceToUpdate.ProductId = deviceUpdate.ProductId ?? deviceToUpdate.ProductId;
            deviceToUpdate.LastMaintenance = (deviceUpdate.LastMaintenance != null) ? DateTime.Parse(deviceUpdate.LastMaintenance) : deviceToUpdate.LastMaintenance;
            deviceToUpdate.NextMaintenance = (deviceUpdate.NextMaintenance != null) ? DateTime.Parse(deviceUpdate.NextMaintenance) : deviceToUpdate.NextMaintenance;
            deviceToUpdate.WarrantyUntil = (deviceUpdate.WarrantyUntil != null) ? DateTime.Parse(deviceUpdate.WarrantyUntil) : deviceToUpdate.WarrantyUntil;
            deviceToUpdate.Status = (deviceUpdate.StatusNumber != null) ? (DeviceStatus)deviceUpdate.StatusNumber : deviceToUpdate.Status;
            deviceToUpdate.CustomerId = deviceUpdate.CustomerId ?? deviceToUpdate.CustomerId;
            deviceToUpdate.OrderId = deviceUpdate.OrderId ?? deviceToUpdate.OrderId;

            return deviceToUpdate;
        }
    }
}
