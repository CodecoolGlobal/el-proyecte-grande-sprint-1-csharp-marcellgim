using BpRobotics.Data.Model;

namespace BpRobotics.Data
{
    public class BpRoboticsDataStorage : IBpRoboticsDataStorage
    {
        public List<Customer> Customers { get; set; }
        public List<Device> Devices { get; set; }
        public List<Order> Orders { get; set; }
        public List<Partner> Partners { get; set; }
        public List<Service> Services { get; set; }
        public List<Ticket> Tickets { get; set; }
        public List<User> Users { get; set; }
        public List<Product> Products { get; set; }

        public BpRoboticsDataStorage()
        {
            Customers = new List<Customer>
            {
                new()
                {
                    CompanyName = "TestCompany",
                    BillingAddress = new Location
                    {
                        City = "TestCity",
                        Address = "TestAddress",
                        Country = "TestCountry",
                        ZIP = 1000
                    },
                    ShippingAddress = new Location
                    {
                        City = "TestCity",
                        Address = "TestAddress",
                        Country = "TestCountry",
                        ZIP = 1000
                    },
                    VatNumber = 123456,
                },
                new()
                {
                    CompanyName = "TestCompany2",
                    BillingAddress = new Location
                    {
                        City = "TestCity2",
                        Address = "TestAddress2",
                        Country = "TestCountry2",
                        ZIP = 1001
                    },
                    ShippingAddress = new Location
                    {
                        City = "TestCity2",
                        Address = "TestAddress2",
                        Country = "TestCountry2",
                        ZIP = 1001
                    },
                    VatNumber = 654321,
                }
            };

            Partners = new List<Partner>
            {
                new()
                {
                    Id = 1,
                    CompanyName = "Partner1",
                    PhoneNumber = "+6786876"
                },
                new()
                {
                    Id = 2,
                    CompanyName = "Partner2",
                    PhoneNumber = "+6786876"
                }
            };

            Users = new List<User>
            {
                new()
                {
                    FirstName = "Lajos",
                    LastName = "Admin",
                    Id = 1,
                    UserName = "AdminLajos",
                    HashedPassword = "1234",
                    Role = UserRole.Admin
                },
                new()
                {
                    FirstName = "Anna",
                    LastName = "Admin",
                    Id = 1,
                    UserName = "AdminAnna",
                    HashedPassword = "1234",
                    Role = UserRole.Admin
                },
                new()
                {
                    FirstName = "Lajos",
                    LastName = "Partner",
                    Id = 2,
                    UserName = "PartnerLajos",
                    HashedPassword = "1234",
                    Role = UserRole.Partner,
                    Partner = Partners[0]
                },
                new()
                {
                    FirstName = "Anna",
                    LastName = "Partner",
                    Id = 2,
                    UserName = "PartnerAnna",
                    HashedPassword = "1234",
                    Role = UserRole.Partner,
                    Partner = Partners[1]
                },
                new() 
                {
                    FirstName = "Lajos",
                    LastName = "Customer",
                    Id = 3,
                    UserName = "CustomerLajos",
                    HashedPassword = "1234",
                    Role = UserRole.Customer,
                    Customer = Customers[0]
                },
                new()
                {
                    FirstName = "Anna",
                    LastName = "Customer",
                    Id = 3,
                    UserName = "CustomerAnna",
                    HashedPassword = "1234",
                    Role = UserRole.Customer,
                    Customer = Customers[1]
                }
            };

            

            Devices = new List<Device>
            {
                new()
                {
                    Id = 1,
                    Serial = "SN97687",
                    Product = Products[0],
                    Services = new List<Service>(),
                    LastMaintenance = DateTime.Now,
                    NextMaintenance = DateTime.Now,
                    WarrantyUntil = DateTime.Now,
                    Status = DeviceStatus.InstallPending,
                    Customer = Customers[0]
                },
                new()
                {
                    Id = 2,
                    Serial = "SN97687",
                    Product = Products[1],
                    Services = new List<Service>(),
                    LastMaintenance = DateTime.Now,
                    NextMaintenance = DateTime.Now,
                    WarrantyUntil = DateTime.Now,
                    Status = DeviceStatus.InstallPending,
                    Customer = Customers[0]
                },
                new()
                {
                    Id = 3,
                    Serial = "SN97687",
                    Product = Products[0],
                    Services = new List<Service>(),
                    LastMaintenance = DateTime.Now,
                    NextMaintenance = DateTime.Now,
                    WarrantyUntil = DateTime.Now,
                    Status = DeviceStatus.InstallPending,
                    Customer = Customers[1]
                },
                new()
                {
                    Id = 4,
                    Serial = "SN97687",
                    Product = Products[1],
                    Services = new List<Service>(),
                    LastMaintenance = DateTime.Now,
                    NextMaintenance = DateTime.Now,
                    WarrantyUntil = DateTime.Now,
                    Status = DeviceStatus.InstallPending,
                    Customer = Customers[1]
                }
            };

            Products = new List<Product>
            {
                new()
                {
                    Id =1,
                    Name = "Smart Air",
                    ServiceInterval = TimeSpan.FromDays(180),
                    Warranty = 730,
                    ShortDescription = "Smart air-condition",
                    LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                },
                new()
                {
                    Id =2,
                    Name = "Smart Fridge",
                    ServiceInterval = TimeSpan.FromDays(365),
                    Warranty = 1095,
                    ShortDescription = "Smart fridge",
                    LongDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                }
            };

            Orders = new List<Order>()
            {
                new()
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Customer = Customers[0],
                    Address = Customers[0].ShippingAddress,
                    Devices = new List<Device>
                    {
                        Devices[0],
                        Devices[1]
                    }
                },
                new()
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Customer = Customers[1],
                    Address = Customers[1].ShippingAddress,
                    Devices = new List<Device>
                    {
                        Devices[2],
                        Devices[3]
                    }
                }
            };
        }
    }
}
