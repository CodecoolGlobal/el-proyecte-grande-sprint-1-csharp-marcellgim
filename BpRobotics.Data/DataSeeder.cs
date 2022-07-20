﻿using BpRobotics.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BpRobotics.Data;

public class DataSeeder
{
    private readonly BpRoboticsContext _context;

    public DataSeeder(BpRoboticsContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        _context.Database.EnsureCreated();

        if (!_context.Users.Any())
        {
            var users = new User[]
            {
                new()
                {
                    FirstName = "Péter",
                    LastName = "Király",
                    UserName = "MainAdmin",
                    HashedPassword = "1234",
                    Role = UserRole.Admin
                },
                new()
                {
                    FirstName = "Sutő",
                    LastName = "Károly",
                    UserName = "BossMan",
                    HashedPassword = "1234",
                    Role = UserRole.Admin
                },
                new()
                {
                    FirstName = "István",
                    LastName = "Takács",
                    UserName = "RepairMan",
                    HashedPassword = "1234",
                    Role = UserRole.Partner,
                },
                new()
                {
                    FirstName = "Anna",
                    LastName = "Partner",
                    UserName = "CreativeUsername",
                    HashedPassword = "1234",
                    Role = UserRole.Partner,
                },
                new()
                {
                    FirstName = "Lajos",
                    LastName = "Customer",
                    UserName = "EcseriFourSeasons",
                    HashedPassword = "1234",
                    Role = UserRole.Customer,
                },
                new()
                {
                    FirstName = "Huba",
                    LastName = "Hűtő",
                    UserName = "ILoveRefrigerators",
                    HashedPassword = "1234",
                    Role = UserRole.Customer,
                }
            };

            _context.Users.AddRange(users);
            _context.SaveChanges();

            _context.Partners.AddRange(
                new()
                {
                    CompanyName = "WeFixIt",
                    PhoneNumber = "+36 69 420 1337",
                    User = users[2]
                },
                new()
                {
                    CompanyName = "3WeFixIt",
                    PhoneNumber = "+36 69 420 1337",
                    User = users[2]
                },
                new()
                {
                    CompanyName = "2WeFixIt",
                    PhoneNumber = "+36 69 420 1337",
                    User = users[2]
                },
                new()
                {
                    CompanyName = "1WeFixIt",
                    PhoneNumber = "+36 69 420 1337",
                    User = users[2]
                },
                new()
                {
                    CompanyName = "InstallersInc",
                    PhoneNumber = "+36 44 999 999",
                    User = users[3]
                }
            );

            _context.SaveChanges();

            var customers = new Customer[]
            {
                new()
                {
                    CompanyName = "Four Seasons",
                    BillingAddress = new Location
                    {
                        City = "Budapest",
                        Address = "Ecseri út 14.",
                        Country = "Hungary",
                        ZIP = 1097
                    },
                    ShippingAddress = new Location
                    {
                        City = "Budapest",
                        Address = "Ecseri út 14.",
                        Country = "Hungary",
                        ZIP = 1097
                    },
                    VatNumber = 123456,
                    User = users[4]
                },
                new()
                {
                    CompanyName = "Rat Co.",
                    BillingAddress = new Location
                    {
                        City = "Kiskunhalas",
                        Address = "Áchim András utca 1.",
                        Country = "Hungary",
                        ZIP = 6400
                    },
                    ShippingAddress = new Location
                    {
                        City = "Kiskunhalas",
                        Address = "Áchim András utca 1.",
                        Country = "Hungary",
                        ZIP = 6400
                    },
                    VatNumber = 654321,
                    User = users[5]
                }
            };

            _context.Customers.AddRange(customers);
            _context.SaveChanges();

            var products = new Product[]
            {
                new()
                {
                    Name = "Smart Air",
                    ServiceInterval = 180,
                    Warranty = 730,
                    ShortDescription = "Smart air-conditioner",
                    LongDescription =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ImageFileName = "smart_ac.jpg"
                },
                new()
                {
                    Name = "Smart Fridge",
                    ServiceInterval = 365,
                    Warranty = 1095,
                    ShortDescription = "Smart fridge",
                    LongDescription =
                        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    ImageFileName= "smart_fridge.jpg"
                }
            };

            _context.Products.AddRange(products);
            _context.SaveChanges();

            var orders = new Order[]
            {
                new()
                {
                    Date = DateTime.Now,
                    Customer = customers[0],
                },
                new()
                {
                    Date = DateTime.Now,
                    Customer = customers[1],
                }
            };

            _context.Orders.AddRange(orders);
            _context.SaveChanges();

            var devices = new Device[]
            {
                new()
                {
                    Serial = "SN97687",
                    Product = products[0],
                    LastMaintenance = DateTime.Now,
                    NextMaintenance = DateTime.Now,
                    WarrantyUntil = DateTime.Now,
                    Status = DeviceStatus.InstallPending,
                    Order = orders[0]
                },
                new()
                {
                    Serial = "SN97687",
                    Product = products[1],
                    LastMaintenance = DateTime.Now,
                    NextMaintenance = DateTime.Now,
                    WarrantyUntil = DateTime.Now,
                    Status = DeviceStatus.InstallPending,
                    Order = orders[0]
                },
                new()
                {
                    Serial = "SN97687",
                    Product = products[0],
                    LastMaintenance = DateTime.Now,
                    NextMaintenance = DateTime.Now,
                    WarrantyUntil = DateTime.Now,
                    Status = DeviceStatus.InstallPending,
                    Order = orders[1]
                },
                new()
                {
                    Serial = "SN97687",
                    Product = products[1],
                    LastMaintenance = DateTime.Now,
                    NextMaintenance = DateTime.Now,
                    WarrantyUntil = DateTime.Now,
                    Status = DeviceStatus.InstallPending,
                    Order = orders[1]
                }
            };

            _context.Devices.AddRange(devices);
            _context.SaveChanges();
        }
    }
}