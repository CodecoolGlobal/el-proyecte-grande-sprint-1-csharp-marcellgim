using BpRobotics.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BpRobotics.Data
{
    public class BpRoboticsContext : DbContext
    {
        public BpRoboticsContext(DbContextOptions<BpRoboticsContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Partner>().ToTable("Partner");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Location>().ToTable("Location");
        }
    }
}
