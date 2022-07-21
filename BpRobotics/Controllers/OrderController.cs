using BpRobotics.Core.Model.Orders;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using BpRobotics.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                var identity = HttpContext.User;
                if (identity != null)
                {
                    var isCustomer = int.TryParse(identity.FindFirst("functionId")?.Value, out int customerId);
                    return isCustomer ? await _orderService.GetAll(customerId) : await _orderService.GetAll();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return Unauthorized();
        }


        [HttpGet("{id}", Name = "GetOrderById")]
        public async Task<ActionResult<OrderViewDTO>> GetOrderById(int id)
        {
            try
            {
                return await _orderService.Get(id);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogCritical($"No order found with id: {id}.", ex);
                return NotFound($"Order with ID:{id} not found.");
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
            catch (InvalidOperationException ex)
            {
                _logger.LogCritical($"No order found with id: {id}.", ex);
                return NotFound($"Order with ID:{id} not found.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<OrderViewDTO>> AddOrder(OrderCreateDTO order)
        {
            try
            {
                var newOrder = await _orderService.Add(order);
                return CreatedAtRoute("GetOrderById", new {id = newOrder.Id}, newOrder);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogCritical("A problem happened while adding Order.");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<OrderViewDTO>> UpdateOrderById(OrderUpdateDTO order)
        {
            try
            {
                return await _orderService.Update(order);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogCritical($"A problem happened while updating Order with id:{order.Id}", ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
