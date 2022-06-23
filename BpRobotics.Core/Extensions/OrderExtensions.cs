using BpRobotics.Core.Model.Orders;
using BpRobotics.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpRobotics.Core.Extensions
{
    public static class OrderExtensions
    {
        public static Order ToOrderEntity(this OrderCreateDTO orderCreateDTO)
        {
            return new Order
            {
                Date = DateTime.Now,
            };
        }

        public static OrderViewDTO ToOrderView(this Order order)
        {
            var devices = new Dictionary<string, int>();

            foreach (var device in order.Devices)
            {
                int count;
                devices.TryGetValue(device.Product.Name, out count);
                devices[device.Product.Name] = count + 1;
            }

            return new OrderViewDTO
            {
                Date = order.Date,
                CustomerId = order.Customer.Id,
                CustomerCompanyName = order.Customer.CompanyName,
                Address = order.Customer.ShippingAddress.ToString(),
                Devices = devices
            };
        }
    }
}
