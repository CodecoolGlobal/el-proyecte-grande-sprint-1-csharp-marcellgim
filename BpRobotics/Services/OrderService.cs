using BpRobotics.Core.Model.Orders;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;

namespace BpRobotics.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _repository;

        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public Task Add(OrderCreateDTO order)
        {
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
