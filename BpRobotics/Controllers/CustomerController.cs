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
                return BadRequest();
            }
        }

        [HttpGet("customers/{id}", Name = "GetCustomerById")]
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
                await _customerService.UpdateCustomer(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError($"No customer found with id: {id}.", ex);
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("customers")]
        public async Task<ActionResult<CustomerDetailedDto>> AddNewCustomer([FromBody] CreateCustomerDto customer)
        {
            try
            {
                var newCustomer = await _customerService.NewCustomer(customer);
                
                return CreatedAtRoute(nameof(GetCustomerById), new { id = newCustomer.Id }, newCustomer);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong with adding new customer.", ex);
                return BadRequest();
            }

        }
    }
}
