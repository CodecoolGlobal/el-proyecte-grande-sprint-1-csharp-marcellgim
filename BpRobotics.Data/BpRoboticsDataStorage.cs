using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BpRobotics.Data.Model;

namespace BpRobotics.Data
{
    internal class BpRoboticsDataStorage : IBpRoboticsDataStorage
    {
        public List<Customer> Customers { get; set; }
        public List<Device> Devices { get; set; }
        public List<Order> Orders { get; set; }
        public List<Partner> Partners { get; set; }
        public List<Service> Services { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<User> Users { get; set; }

        public BpRoboticsDataStorage()
        {
            Customers = new List<Customer>() {
                new Customer() {
                CompanyName = "TestCompany",
                BillingAddress = new Location() {
                    City = "TestCity",
                    Address = "TestAddress",
                    Country = "TestCountry",
                    ZIP = 1000
                },
                ShippingAddress = new Location() {
                    City = "TestCity",
                    Address = "TestAddress",
                    Country = "TestCountry",
                    ZIP = 1000
                },
                VatNumber = 123456,
                },
                new Customer() {
                CompanyName = "TestCompany2",
                BillingAddress = new Location() {
                    City = "TestCity2",
                    Address = "TestAddress2",
                    Country = "TestCountry2",
                    ZIP = 1001
                },
                ShippingAddress = new Location() {
                    City = "TestCity2",
                    Address = "TestAddress2",
                    Country = "TestCountry2",
                    ZIP = 1001
                },
                VatNumber = 654321,
                }
            };
            Users = new List<User>() {
                new User() {
                    FirstName = "Lajos",
                    LastName = "Lakatos",
                    Id = 1,
                    UserName = "AdminLajos",
                    HashedPassword = "1234",
                    Role = UserRole.Admin },
                new User() {
                    FirstName = "Lajos",
                    LastName = "Lakatos",
                    Id = 2,
                    UserName = "PartnerLajos",
                    HashedPassword = "1234",
                    Role = UserRole.Partner },
                new User() {
                    FirstName = "Lajos",
                    LastName = "Lakatos",
                    Id = 3,
                    UserName = "CustomerLajos",
                    HashedPassword = "1234",
                    Role = UserRole.Customer }
            };
            }

        }
    }
}
