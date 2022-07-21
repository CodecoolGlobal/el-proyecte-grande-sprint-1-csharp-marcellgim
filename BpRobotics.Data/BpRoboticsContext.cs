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
        public DbSet<Device> Devices { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Customer>()
                .ToTable("Customer")
                .OwnsOne(e => e.BillingAddress);

            modelBuilder.Entity<Customer>()
                .OwnsOne(e => e.ShippingAddress);

            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Product>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Partner>().ToTable("Partner");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Device>().ToTable("Device");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<User>().Property<bool>("IsDeleted");
            modelBuilder.Entity<User>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Customer>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Customer>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Order>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Order>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Device>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Device>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Service>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Service>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
            modelBuilder.Entity<Partner>().Property<bool>("IsDeleted");
            modelBuilder.Entity<Partner>().HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);


        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }
    }
}
