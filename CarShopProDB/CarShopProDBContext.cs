using CarShopProDB.Tables;
using Microsoft.EntityFrameworkCore;

namespace CarShopProDB
{
    public class CarShopProDBContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Car)
                .WithMany()
                .HasForeignKey(o => o.CarId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Part)
                .WithMany()
                .HasForeignKey(o => o.PartId);

            modelBuilder.Entity<Car>()
                .HasKey(c => c.CarId);

            modelBuilder.Entity<Part>()
                .HasKey(p => p.PartId);

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<Supplier>()
                .HasKey(s => s.SupplierId);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source=CarShopPro.db");
        }

    }
}