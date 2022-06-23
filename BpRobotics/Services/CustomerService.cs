using BpRobotics.Core.Extensions;
using BpRobotics.Core.Model;
using BpRobotics.Core.Model.CustomerDTOs;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;

namespace BpRobotics.Services
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerDto>> ListCustomers()
        {
            var customers = await _customerRepository.GetAll();
            return customers.ToCustomerView();
        }

        public async Task<CustomerDetailedDto> GetById(int customerId)
        {
            var customer = await _customerRepository.Get(customerId);
            return customer.ToCustomerDetailedView();
        }

        public async Task<CustomerDetailedDto> NewCustomer(CreateCustomerDto newCustomerDto)
        {
            var customerEntity = newCustomerDto.ToCustomerEntity();
            await _customerRepository.Add(customerEntity);

            return customerEntity.ToCustomerDetailedView();
        }

        public async Task<CustomerDetailedDto> UpdateUser(CustomerUpdateDto updatedCustomerDto)
        {
            var customerModel = await CreateCustomerModelById(updatedCustomerDto);

            await _customerRepository.Update(customerModel.ToCustomerEntity());

            return customerModel.ToCustomerDetailedView();
        }

        public async Task DeleteById(int customerId) => await _customerRepository.Delete(customerId);

        private async Task<CustomerModel> CreateCustomerModelById(CustomerUpdateDto updatedCustomerDto)
        {
            var customerId = updatedCustomerDto.Id;
            var customerModel = updatedCustomerDto.ToCustomerModel();

            var customerEntity = await _customerRepository.Get(customerId);
            customerModel.User = customerEntity.User;

            return customerModel;
        }
    }
}
