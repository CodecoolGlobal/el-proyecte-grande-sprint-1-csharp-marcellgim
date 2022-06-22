using BpRobotics.Core.Model.CustomerDTOs;
using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Extensions
{
    public static class CustomerExtensions
    {
        public static CustomerDTO ToCustomerView(this Customer customer)
        {
            return new CustomerDTO
            {
                Id = customer.Id,
                CompanyName = customer.CompanyName,
                VatNumber = customer.VatNumber,
            };
        }

        public static List<CustomerDTO> ToCustomerView(this List<Customer> customers)
        {
            return customers.Select(ToCustomerView).ToList();
        }

        public static CustomerDetailedDTO ToCustomerDetailedView(this Customer customer)
        {
            return new CustomerDetailedDTO
            {
                Id = customer.Id,
                CompanyName = customer.CompanyName,
                VatNumber = customer.VatNumber,
                BillingZIP = customer.BillingAddress.ZIP,
                BillingCountry = customer.BillingAddress.Country,
                BillingCity = customer.BillingAddress.City,
                BillingAddress = customer.BillingAddress.Address,
                ShippingZIP = customer.ShippingAddress.ZIP,
                ShippingCountry = customer.ShippingAddress.Country,
                ShippingCity = customer.ShippingAddress.City,
                ShippingAddress = customer.ShippingAddress.Address
            };
        }

        public static CustomerDetailedDTO ToCustomerDetailedView(this CustomerModel customer)
        {
            return new CustomerDetailedDTO
            {
                Id = customer.Id,
                CompanyName = customer.CompanyName,
                VatNumber = customer.VatNumber,
                BillingZIP = customer.BillingAddress.ZIP,
                BillingCountry = customer.BillingAddress.Country,
                BillingCity = customer.BillingAddress.City,
                BillingAddress = customer.BillingAddress.Address,
                ShippingZIP = customer.ShippingAddress.ZIP,
                ShippingCountry = customer.ShippingAddress.Country,
                ShippingCity = customer.ShippingAddress.City,
                ShippingAddress = customer.ShippingAddress.Address
            };
        }

        public static Customer ToCustomerEntity(this CustomerDetailedDTO customer)
        {
            var billingLocation = new Location
            {
                ZIP = customer.BillingZIP,
                Country = customer.BillingCountry,
                City = customer.BillingCity,
                Address = customer.BillingAddress
            };

            var shippingLocation = new Location
            {
                ZIP = customer.ShippingZIP,
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

        public static CustomerModel ToCustomerModel(this CustomerUpdateDTO updateCustomerDto)
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
