using BpRobotics.Data.Model;
using BpRobotics.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BpRobotics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("customers")]
        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        [HttpGet("customers/{id}")]
        public Customer GetCustomerById([FromRoute] int id)
        {
            return _customerRepository.Get(id);
        }
    }
}
