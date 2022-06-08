using BpRobotics.Data.Model;
using BpRobotics.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly ILogger<OrderController> _logger;
        public OrderController(IRepository<Order> repository, ILogger<OrderController> logger)
        {
            _orderRepository = repository;
            _logger = logger;
        }

        [HttpGet("orders")]
        public ActionResult<List<Order>> GetAllOrders()
        {
            try
            {
                return Ok(_orderRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogCritical("", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }


        [HttpGet("orders/{id}")]
        public ActionResult<Order> GetOrderById([FromRoute] int id)
        {
            try
            {
                return Ok(_orderRepository.Get(id));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"A problem happened while getting Order with id:{id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpDelete("orders/{id}")]
        public ActionResult DeleteOrderById([FromRoute]int id)
        {
            try
            {
                _orderRepository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"A problem happened while deleting Order with id:{id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost("orders")]
        public ActionResult AddOrder([FromBody]Order order)
        {
            var newId = _orderRepository.GetAll().OrderBy(order => order.Id).Last().Id + 1;
            order.Id = newId;

            try
            {
                _orderRepository.Add(order);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"A problem happened while adding Order with id:{order.Id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPut("orders/{id}")]
        public ActionResult UpdateOrderById([FromRoute]int id, [FromBody]Order order)
        {
            try
            {
                _orderRepository.Update(id, order);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"A problem happened while updating Order with id:{order.Id}", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }
    }
}
