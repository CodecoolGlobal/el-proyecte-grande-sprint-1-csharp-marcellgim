using BpRobotics.Core.Model.Orders;

namespace BpRobotics.Services
{
    public interface IOrderService
    {
        Task<List<OrderViewDTO>> GetAll(int customerId);
        Task<List<OrderViewDTO>> GetAll();
        Task<OrderViewDTO> Get(int id);
        Task<OrderViewDTO> Add(OrderCreateDTO order);
        Task Delete(int id);
        Task<OrderViewDTO> Update(OrderUpdateDTO order);
    }
}
