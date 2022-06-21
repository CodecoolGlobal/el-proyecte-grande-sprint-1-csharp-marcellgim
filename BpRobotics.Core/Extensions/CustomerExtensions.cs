using BpRobotics.Core.Model.CustomerDTOs;
using BpRobotics.Data.Entity;

namespace BpRobotics.Core.Extensions
{
    public static class CustomerExtensions
    {
        public static ReadCustomerDTO ToCustomerView(this Customer customer)
        {
            return new ReadCustomerDTO
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
        public static List<ReadCustomerDTO> ToCustomerView(this List<Customer> customers)
        {
            return customers.Select(ToCustomerView).ToList();
        }

        public static UpdateCustomerDTO ToUpdateCustomerView(this Customer customer)
        {
            return new UpdateCustomerDTO
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
        public static List<UpdateCustomerDTO> ToUpdateCustomerView(this List<Customer> customers)
        {
            return customers.Select(ToUpdateCustomerView).ToList();
        }

        public static CreateCustomerDTO ToCreateCustomerView(this Customer customer)
        {
            return new CreateCustomerDTO
            {
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
        public static List<CreateCustomerDTO> ToCreateCustomerView(this List<Customer> customers)
        {
            return customers.Select(ToCreateCustomerView).ToList();
        }

        public static Customer ToCustomerEntity(this CreateCustomerDTO customer)
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
        public static List<Customer> ToCustomerEntity(this List<CreateCustomerDTO> customers)
        {
            return customers.Select(ToCustomerEntity).ToList();
        }
    }
}
