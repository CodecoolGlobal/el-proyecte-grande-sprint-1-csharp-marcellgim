﻿using BpRobotics.Core.Model.Orders;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;

namespace BpRobotics.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Device> _deviceRepository;

        public OrderService(IRepository<Order> orderRepository, IRepository<Customer> customerRepository, IRepository<Device> deviceRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _deviceRepository = deviceRepository;
        }

        public async Task<OrderViewDTO> Add(OrderCreateDTO order)
        {
            var customer = await _customerRepository.Get(order.CustomerId);
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderViewDTO> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderViewDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderViewDTO> Update(OrderUpdateDTO order)
        {
            throw new NotImplementedException();
        }
    }
}
