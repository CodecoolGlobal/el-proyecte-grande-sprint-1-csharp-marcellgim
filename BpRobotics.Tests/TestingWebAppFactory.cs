using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BpRobotics.Data;
using BpRobotics.Data.Entity;
using BpRobotics.Data.Repositories;
using BpRobotics.Services;

namespace BpRobotics.Tests
{
    internal class TestingWebAppFactory<T> : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContext = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<BpRoboticsContext>));
                if (dbContext != null)
                    services.Remove(dbContext);

                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<BpRoboticsContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryTestDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddTransient<IUserRepository, UserRepository>();
                services.AddTransient<IRepository<Order>, OrderRepository>();
                services.AddTransient<IRepository<Product>, ProductRepository>();
                services.AddTransient<IRepository<Customer>, CustomerRepository>();
                services.AddTransient<IRepository<Partner>, PartnerRepository>();
                services.AddTransient<IRepository<Device>, DeviceRepository>();

                services.AddTransient<UserService>();
                services.AddTransient<ProductService>();
                services.AddTransient<IOrderService, OrderService>();
                services.AddTransient<IPartnersService, PartnersService>();
                services.AddTransient<CustomerService>();

                services.AddTransient<DataSeeder>();



                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var initializer = scope.ServiceProvider.GetRequiredService<DataSeeder>();
                using var appContext = scope.ServiceProvider.GetRequiredService<BpRoboticsContext>();
                try
                {
                    appContext.Database.EnsureDeleted();
                    initializer.Seed();
                }
                catch (Exception ex)
                {
                    //Log errors
                    throw;
                }
            });
        }
    }
}