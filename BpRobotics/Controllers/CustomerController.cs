using BpRobotics.Data.Model;
using BpRobotics.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IRepository<Customer> customerRepository, ILogger<CustomerController> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        [HttpGet("customers")]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            try
            {
                return Ok(_customerRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Customers could not get", ex);
                return StatusCode(500, "Something went wrong with your request.");
            }
        }

        [HttpGet("customers/{id}")]
        public ActionResult<Customer> GetCustomerById([FromRoute] int id)
        {
            try
            {
                return Ok(_customerRepository.Get(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Customers does not exists with id: {id}", ex);
                return NotFound();
            }
        }

        [HttpDelete("customers/{id}")]
        public ActionResult DeleteCustomerById([FromRoute] int id)
        {
            try
            {
                _customerRepository.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"No customer found with id: {id}", ex);
                return NotFound();
            }

            return NoContent();
        }
    }
}
