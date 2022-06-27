using BpRobotics.Core.Model.CustomerDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Services;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [Route("api/customers")]
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

        [HttpGet]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            try
            {
                var customers = await _customerService.ListCustomers();
                return customers;
            }
            catch (Exception ex)
            {
                _logger.LogError("Customers could not get.", ex);
                return BadRequest();
            }
        }

        [HttpGet("{id}", Name = "GetCustomerById")]
        public async Task<ActionResult<CustomerDetailedDto>> GetCustomerById(int id)
        {
            try
            {
                return await _customerService.GetById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Customers does not exists with id: {id}.", ex);
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomerById(int id)
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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomerById(int id, CustomerUpdateDto customer)
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

        [HttpPost]
        public async Task<ActionResult<CustomerDetailedDto>> AddNewCustomer(CreateCustomerDto customer)
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
