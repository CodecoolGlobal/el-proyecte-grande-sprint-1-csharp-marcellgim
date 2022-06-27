using BpRobotics.Core.Model.Orders;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using BpRobotics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderViewDTO>>> GetAllOrders()
        {
            try
            {
                return await _orderService.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogCritical("", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }


        [HttpGet("{id}", Name = "GetOrderById")]
        public async Task<ActionResult<OrderViewDTO>> GetOrderById(int id)
        {
            try
            {
                return await _orderService.Get(id);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"A problem happened while getting Order with id:{id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderById(int id)
        {
            try
            {
                await _orderService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"A problem happened while deleting Order with id:{id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder(OrderCreateDTO order)
        {
            try
            {
                var newOrder = await _orderService.Add(order);
                return CreatedAtRoute("GetOrderById", new {id = newOrder.Id}, newOrder);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("A problem happened while adding Order.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPut]
        public async Task<ActionResult<OrderViewDTO>> UpdateOrderById(OrderUpdateDTO order)
        {
            try
            {
                return await _orderService.Update(order);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"A problem happened while updating Order with id:{order.Id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }
    }
}
