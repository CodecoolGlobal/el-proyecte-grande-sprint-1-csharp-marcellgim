using BpRobotics.Core.Extensions;
using BpRobotics.Core.Model.CustomerDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;

namespace BpRobotics.Services
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IUserRepository _userRepository;
        public CustomerService(IRepository<Customer> customerRepository, IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        public async Task<List<CustomerDetailedDto>> ListCustomers()
        {
            var customers = await _customerRepository.GetAll();
            return customers.ToCustomerDetailedView();
        }

        public async Task<CustomerDetailedDto> GetById(int customerId)
        {
            var customer = await _customerRepository.Get(customerId);
            return customer.ToCustomerDetailedView();
        }

        public async Task<CustomerDetailedDto> NewCustomer(CreateCustomerDto newCustomerDto)
        {
            var customerEntity = newCustomerDto.ToCustomerEntity();
            customerEntity.User = await _userRepository.Get(newCustomerDto.UserId);
            await _customerRepository.Add(customerEntity);

            return customerEntity.ToCustomerDetailedView();
        }

        public async Task<CustomerDetailedDto> UpdateCustomer(CustomerUpdateDto updatedCustomerDto)
        {
            await _customerRepository.Update(updatedCustomerDto.ToCustomerEntity());

            return updatedCustomerDto.ToCustomerDetailedView();
        }

        public async Task DeleteById(int customerId) => await _customerRepository.Delete(customerId);
    }
}
