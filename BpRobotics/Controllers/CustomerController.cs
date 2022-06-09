using BpRobotics.Data.Entity;
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
                return Ok(_customerRepository.GetAll().OrderBy(customer => customer.Id));
            }
            catch (Exception ex)
            {
                _logger.LogError("Customers could not get.", ex);
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
                _logger.LogError($"Customers does not exists with id: {id}.", ex);
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
                _logger.LogError($"No customer found with id: {id}.", ex);
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("customers/{id}")]
        public ActionResult UpdateCustomerById([FromRoute] int id, [FromBody] Customer customer)
        {
            try
            {
                _customerRepository.Update(id, customer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"No customer found with id: {id}.", ex);
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("customers")]
        public ActionResult<Customer> AddNewCustomer([FromBody] Customer customer)
        {
            var newId = _customerRepository.GetAll().OrderBy(c => c.Id).Last().Id + 1;
            customer.Id = newId;

            try
            {
                _customerRepository.Add(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong with adding new customer.", ex);
                return StatusCode(500, "Something went wrong with your request.");
            }

            return CreatedAtRoute(nameof(GetCustomerById), customer);
        }
    }
}
