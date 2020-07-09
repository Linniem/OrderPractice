using Microsoft.EntityFrameworkCore;
using OrderPractice.Models;

namespace OrderPractice.Data
{
    public class OrderPracticeContext : DbContext
    {
        public OrderPracticeContext(DbContextOptions<OrderPracticeContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusName = "Payment completed" },
                new Status { StatusId = 2, StatusName = "To be shipped" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Product1" },
                new Product { ProductId = 2, ProductName = "Product2" },
                new Product { ProductId = 3, ProductName = "Product3" },
                new Product { ProductId = 4, ProductName = "Product4" }
                );
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = "A20202026001", OrderProductId = 1, Price = 100, Cost = 90, StatusCode = 1 },
                new Order { OrderId = "A20202026002", OrderProductId = 2, Price = 120, Cost = 100, StatusCode = 1 },
                new Order { OrderId = "A20202026003", OrderProductId = 3, Price = 200, Cost = 150, StatusCode = 1 },
                new Order { OrderId = "A20202026004", OrderProductId = 4, Price = 150, Cost = 120, StatusCode = 1 }
                );
        }
    }
}
