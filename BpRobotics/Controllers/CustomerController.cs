using BpRobotics.Core.Model.CustomerDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Services;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(CustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet("customers")]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerService.ListCustomers();
                return Ok(customers.OrderBy(customer => customer.Id));
            }
            catch (Exception ex)
            {
                _logger.LogError("Customers could not get.", ex);
                return StatusCode(500, "Something went wrong with your request.");
            }
        }

        [HttpGet("customers/{id}")]
        public async Task<ActionResult<CustomerDetailedDto>> GetCustomerById([FromRoute] int id)
        {
            try
            {
                return Ok(await _customerService.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Customers does not exists with id: {id}.", ex);
                return NotFound();
            }
        }

        [HttpDelete("customers/{id}")]
        public async Task<ActionResult> DeleteCustomerById([FromRoute] int id)
        {
            try
            {
                await _customerService.DeleteById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"No customer found with id: {id}.", ex);
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("customers/{id}")]
        public async Task<ActionResult> UpdateCustomerById([FromRoute] int id, [FromBody] CustomerUpdateDto customer)
        {
            try
            {
                customer.Id = id;
                await _customerService.UpdateUser(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"No customer found with id: {id}.", ex);
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("customers")]
        public async Task<ActionResult<Customer>> AddNewCustomer([FromBody] CustomerDetailedDto customer)
        {
            try
            {
                await _customerService.NewCustomer(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong with adding new customer.", ex);
                return StatusCode(500, "Something went wrong with your request.");
            }

            return CreatedAtRoute(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }
    }
}
