using BpRobotics.Core.Model.CustomerDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InvalidOperationException = System.InvalidOperationException;

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
            return await _customerService.ListCustomers();
        }

        [HttpGet("{id}", Name = "GetCustomerById")]
        public async Task<ActionResult<CustomerDetailedDto>> GetCustomerById(int id)
        {
            try
            {
                return await _customerService.GetById(id);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError($"No customer found with id: {id}.", ex);
                return NotFound($"Customer with ID:{id} not found.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomerById(int id)
        {
            try
            {
                await _customerService.DeleteById(id);
                return NoContent();

            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError($"No customer found with id: {id}.", ex);
                return NotFound($"Customer with ID:{id} not found.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDetailedDto>> UpdateCustomerById(int id, CustomerUpdateDto customer)
        {
            try
            {
                customer.Id = id;
                return await _customerService.UpdateCustomer(customer);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"No customer found with id: {id}.", ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomerDetailedDto>> AddNewCustomer(CreateCustomerDto customer)
        {
            try
            {
                var newCustomer = await _customerService.NewCustomer(customer);
                
                return CreatedAtRoute(nameof(GetCustomerById), new { id = newCustomer.Id }, newCustomer);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError("Something went wrong with adding new customer.");
                return BadRequest(ex.Message);
            }

        }
    }
}
