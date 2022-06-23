using BpRobotics.Core.Extensions;
using BpRobotics.Core.Model.Orders;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;

namespace BpRobotics.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Device> _deviceRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Product> _productRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Device> deviceRepository, IRepository<Customer> customerRepository, IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _deviceRepository = deviceRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderViewDTO> Add(OrderCreateDTO order)
        {
            var orderEntity = order.ToOrderEntity();

            var costumer = _customerRepository.Get(order.CustomerId);
            foreach (var productIDandQuant in order.ProductIdsAndQuantity)
            {
                var product = await _productRepository.Get(productIDandQuant.Key);
                for (int i = 0; i < productIDandQuant.Value; i++)
                {
                    var device = new Device { Product = product, Status = DeviceStatus.InstallPending };
                    await _deviceRepository.Add(device);
                    orderEntity.Devices.Add(device);
                }
            }

            await _orderRepository.Add(orderEntity);

            return orderEntity.ToOrderView();
        }

        public async Task Delete(int id)
        {
            await _orderRepository.Delete(id);
        }

        public async Task<OrderViewDTO> Get(int id)
        {
            return (await _orderRepository.Get(id)).ToOrderView();
        }

        public async Task<List<OrderViewDTO>> GetAll()
        {
            return (await _orderRepository.GetAll()).Select(o => o.ToOrderView()).ToList();
        }

        public async Task<OrderViewDTO> Update(OrderUpdateDTO order)
        {
            throw new NotImplementedException();
        }
    }
}
