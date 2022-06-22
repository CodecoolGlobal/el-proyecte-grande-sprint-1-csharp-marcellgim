using BpRobotics.Core.Model.CustomerDTOs;
using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Extensions
{
    public static class CustomerExtensions
    {
        public static CustomerDto ToCustomerView(this Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                CompanyName = customer.CompanyName,
                VatNumber = customer.VatNumber,
            };
        }

        public static List<CustomerDto> ToCustomerView(this List<Customer> customers)
        {
            return customers.Select(ToCustomerView).ToList();
        }

        public static CustomerDetailedDto ToCustomerDetailedView(this Customer customer)
        {
            return new CustomerDetailedDto
            {
                Id = customer.Id,
                CompanyName = customer.CompanyName,
                VatNumber = customer.VatNumber,
                BillingZip = customer.BillingAddress.ZIP,
                BillingCountry = customer.BillingAddress.Country,
                BillingCity = customer.BillingAddress.City,
                BillingAddress = customer.BillingAddress.Address,
                ShippingZip = customer.ShippingAddress.ZIP,
                ShippingCountry = customer.ShippingAddress.Country,
                ShippingCity = customer.ShippingAddress.City,
                ShippingAddress = customer.ShippingAddress.Address
            };
        }

        public static CustomerDetailedDto ToCustomerDetailedView(this CustomerModel customer)
        {
            return new CustomerDetailedDto
            {
                Id = customer.Id,
                CompanyName = customer.CompanyName,
                VatNumber = customer.VatNumber,
                BillingZip = customer.BillingAddress.ZIP,
                BillingCountry = customer.BillingAddress.Country,
                BillingCity = customer.BillingAddress.City,
                BillingAddress = customer.BillingAddress.Address,
                ShippingZip = customer.ShippingAddress.ZIP,
                ShippingCountry = customer.ShippingAddress.Country,
                ShippingCity = customer.ShippingAddress.City,
                ShippingAddress = customer.ShippingAddress.Address
            };
        }

        public static Customer ToCustomerEntity(this CreateCustomerDto customer)
        {
            var billingLocation = new Location
            {
                ZIP = customer.BillingZip,
                Country = customer.BillingCountry,
                City = customer.BillingCity,
                Address = customer.BillingAddress
            };

            var shippingLocation = new Location
            {
                ZIP = customer.ShippingZip,
                Country = customer.ShippingCountry,
                City = customer.ShippingCity,
                Address = customer.ShippingAddress
            };

            return new Customer
            {
                CompanyName = customer.CompanyName,
                VatNumber = customer.VatNumber,
                BillingAddress = billingLocation,
                ShippingAddress = shippingLocation
            };
        }

        public static Customer ToCustomerEntity(this CustomerModel customerModel)
        {
            return new Customer
            {
                Id = customerModel.Id,
                CompanyName = customerModel.CompanyName,
                VatNumber = customerModel.VatNumber,
                BillingAddress = customerModel.BillingAddress,
                ShippingAddress = customerModel.ShippingAddress
            };
        }

        public static CustomerModel ToCustomerModel(this CustomerUpdateDto updateCustomerDto)
        {
            return new CustomerModel
            {
                Id = updateCustomerDto.Id,
                CompanyName = updateCustomerDto.CompanyName,
                VatNumber = updateCustomerDto.VatNumber
            };
        }
    }
}
