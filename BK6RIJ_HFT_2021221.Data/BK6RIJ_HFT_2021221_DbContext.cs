using System;
using BK6RIJ_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BK6RIJ_HFT_2021221.Data
{
    public class BK6RIJ_HFT_2021221_DbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public BK6RIJ_HFT_2021221_DbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\BK6RIJ_HTF_2021221.mdf;Integrated Security=True";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity
                .HasOne(order => order.Customer)
                .WithMany(customer => customer.Orders)
                .HasForeignKey(order => order.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity
                .HasOne(order => order.Product)
                .WithMany(product => product.Orders)
                .HasForeignKey(order => order.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity
                .HasOne(order => order.Delivery)
                .WithMany(delivery => delivery.Orders)
                .HasForeignKey(order => order.DeliveryId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            Delivery fox = new Delivery { Id = 1, Company = "FoxPost", DeliveryDays = 6 };
            Delivery gls = new Delivery { Id = 2, Company = "GLS", DeliveryDays = 3 };
            Delivery exp = new Delivery { Id = 3, Company = "ExpressOne", DeliveryDays = 2 };
            Delivery post = new Delivery { Id = 4, Company = "Hungarian Post", DeliveryDays = 14 };
            Product p1 = new Product { Id = 1, Name = "Bread", Price = 300 };
            Product p2 = new Product { Id = 2, Name = "Milk", Price = 200 };
            Product p3 = new Product { Id = 3, Name = "Headset", Price = 10000 };
            Product p4 = new Product { Id = 4, Name = "Flower", Price = 3000 };
            Product p5 = new Product { Id = 5, Name = "Cake", Price = 5632 };
            Product p6 = new Product { Id = 6, Name = "Shoes", Price = 20000 };
            Customer c1 = new Customer { Id = 1, FirstName = "Kovacs", LastName = "Bela" };
            Customer c2 = new Customer { Id = 2, FirstName = "Kovacs", LastName = "Erzsebet" };
            Customer c3 = new Customer { Id = 3, FirstName = "Nagy", LastName = "Pistike" };
            Customer c4 = new Customer { Id = 4, FirstName = "Varga", LastName = "Virag" };

            List<Order> orders = new List<Order>()
            {
                new Order { OrderId = 1, CustomerId = 4, ProductId = 4, DeliveryId = 3, OrderDate = new DateTime(2021, 10, 14) },
                new Order { OrderId = 2, CustomerId = 2, ProductId = 5, DeliveryId = 2, OrderDate = new DateTime(2021, 07, 26) },
                new Order { OrderId = 3, CustomerId = 2, ProductId = 3, DeliveryId = 4, OrderDate = new DateTime(2021, 07, 16) },
                new Order { OrderId = 4, CustomerId = 3, ProductId = 6, DeliveryId = 1, OrderDate = new DateTime(2021, 03, 04) },
                new Order { OrderId = 5, CustomerId = 1, ProductId = 1, DeliveryId = 2, OrderDate = new DateTime(2021, 09, 30) },
                new Order { OrderId = 6, CustomerId = 4, ProductId = 4, DeliveryId = 3, OrderDate = new DateTime(2021, 10, 30) },
                new Order { OrderId = 7, CustomerId = 3, ProductId = 3, DeliveryId = 1, OrderDate = new DateTime(2021, 11, 30) },
                new Order { OrderId = 8, CustomerId = 2, ProductId = 5, DeliveryId = 2, OrderDate = new DateTime(2021, 08, 30) },
                new Order { OrderId = 9, CustomerId = 1, ProductId = 2, DeliveryId = 1, OrderDate = new DateTime(2021, 07, 30) },
                new Order { OrderId = 10, CustomerId = 1, ProductId = 1, DeliveryId = 2, OrderDate = new DateTime(2020, 06, 30) },
                new Order { OrderId = 11, CustomerId = 4, ProductId = 4, DeliveryId = 3, OrderDate = new DateTime(2020, 10, 14) },
                new Order { OrderId = 12, CustomerId = 2, ProductId = 5, DeliveryId = 2, OrderDate = new DateTime(2020, 07, 26) },
                new Order { OrderId = 13, CustomerId = 2, ProductId = 3, DeliveryId = 4, OrderDate = new DateTime(2020, 07, 16) },
                new Order { OrderId = 14, CustomerId = 3, ProductId = 6, DeliveryId = 1, OrderDate = new DateTime(2020, 03, 04) },
                new Order { OrderId = 15, CustomerId = 1, ProductId = 1, DeliveryId = 2, OrderDate = new DateTime(2020, 09, 30) },
                new Order { OrderId = 16, CustomerId = 4, ProductId = 4, DeliveryId = 3, OrderDate = new DateTime(2020, 10, 30) },
                new Order { OrderId = 17, CustomerId = 3, ProductId = 3, DeliveryId = 1, OrderDate = new DateTime(2020, 11, 30) },
                new Order { OrderId = 18, CustomerId = 2, ProductId = 5, DeliveryId = 2, OrderDate = new DateTime(2020, 08, 30) },
                new Order { OrderId = 19, CustomerId = 1, ProductId = 2, DeliveryId = 1, OrderDate = new DateTime(2020, 07, 30) },
                new Order { OrderId = 20, CustomerId = 1, ProductId = 1, DeliveryId = 2, OrderDate = new DateTime(2020, 06, 30) },
            };



            modelBuilder.Entity<Delivery>().HasData(fox, gls, exp, post);
            modelBuilder.Entity<Product>().HasData(p1, p2, p3, p4, p5, p6);
            modelBuilder.Entity<Customer>().HasData(c1, c2, c3, c4);
            modelBuilder.Entity<Order>().HasData(orders);
        }
    }
}