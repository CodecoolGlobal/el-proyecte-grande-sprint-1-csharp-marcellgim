using BpRobotics.Core.Model.Orders;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using BpRobotics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [Route("api/")]
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

        [HttpGet("orders")]
        public async Task<ActionResult<List<OrderViewDTO>>> GetAllOrders()
        {
            try
            {
                return Ok(await _orderService.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogCritical("", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }


        [HttpGet("orders/{id}")]
        public async Task<ActionResult<OrderViewDTO>> GetOrderById([FromRoute] int id)
        {
            try
            {
                return Ok(await _orderService.Get(id));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"A problem happened while getting Order with id:{id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpDelete("orders/{id}")]
        public async Task<ActionResult> DeleteOrderById([FromRoute]int id)
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

        [HttpPost("orders")]
        public async Task<ActionResult> AddOrder([FromBody]OrderCreateDTO order)
        {
            try
            {
                await _orderService.Add(order);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical("A problem happened while adding Order.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPut("orders/")]
        public async Task<ActionResult<OrderViewDTO>> UpdateOrderById([FromBody]OrderUpdateDTO order)
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
