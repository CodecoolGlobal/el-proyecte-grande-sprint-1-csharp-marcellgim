using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;

namespace BpRobotics.Services
{
    public class OrderService
    {
        private readonly IRepository<Order> _repository;

        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Order> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task AddNewOrder(Order order)
        {
            await _repository.Add(order);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<Order> Update(Order order)
        {
            return await _repository.Update(order);
        }
    }
}
