using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_program.Models
{
    internal class ECommerceProgramContext : DbContext
    {
        private static IConfiguration _configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public ECommerceProgramContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "iPhone 13 Pro", Description = "Smartphone med 128GB lagring", 
                    Price = 11999, StockQuantity = 15, CategoryId = 1, SupplierId = 1},
                new Product { ProductId = 2, Name = "Samsung TV 55\"", Description = "4K Smart TV med HDR", 
                    Price = 8999, StockQuantity = 8, CategoryId = 1, SupplierId = 5},
                new Product { ProductId = 3, Name = "Sony WH-1000XM4", Description = "Trådlösa hörlurar med brusreducering", 
                    Price = 3499, StockQuantity = 7, CategoryId = 1, SupplierId = 5},
                new Product { ProductId = 4, Name = "MacBook Air", Description = "Laptop med M1-chip och 8GB RAM", 
                    Price = 12499, StockQuantity = 12, CategoryId = 1, SupplierId = 1},
                new Product { ProductId = 5, Name = "Espressomaskin", Description = "Automatisk espressomaskin", 
                    Price = 4995, StockQuantity = 6, CategoryId = 2, SupplierId = 2},
                new Product { ProductId = 6, Name = "Matberedare", Description = "Multifunktionell köksmaskin", 
                    Price = 1299, StockQuantity = 20, CategoryId = 2, SupplierId = 2},
                new Product { ProductId = 7, Name = "Vinterjacka", Description = "Varm jacka för vinterbruk", 
                    Price = 1999, StockQuantity = 25, CategoryId = 3, SupplierId = 3},
                new Product { ProductId = 8, Name = "Löparskor", Description = "Skor för långdistanslöpning", 
                    Price = 1499, StockQuantity = 18, CategoryId = 4, SupplierId = 4},
                new Product { ProductId = 9, Name = "Yogamatta", Description = "Halkfri yogamatta", 
                    Price = 349, StockQuantity = 30, CategoryId = 4, SupplierId = 4},
                new Product { ProductId = 10, Name = "Bestsellerroman", Description = "Populär skönlitterär roman", 
                    Price = 249, StockQuantity = 40, CategoryId = 5, SupplierId = 2},
                new Product { ProductId = 11, Name = "Gaming PC", Description = "Högpresterande dator för gaming", 
                    Price = 18999, StockQuantity = 5, CategoryId = 1, SupplierId = 6},
                new Product { ProductId = 12, Name = "Tablet", Description = "10\" surfplatta med WiFi", 
                    Price = 4299, StockQuantity = 9, CategoryId = 1, SupplierId = 5},
                new Product { ProductId = 13, Name = "Bluetooth-högtalare", Description = "Portabel högtalare med 20h batteritid", 
                    Price = 899, StockQuantity = 22, CategoryId = 1, SupplierId = 6},
                new Product { ProductId = 14, Name = "Kaffebryggare", Description = "Programmerbar kaffebryggare", 
                    Price = 799, StockQuantity = 14, CategoryId = 2, SupplierId = 2},
                new Product { ProductId = 15, Name = "Träningströja", Description = "Funktionströja för träning", 
                    Price = 499, StockQuantity = 35, CategoryId = 3, SupplierId = 3}
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics", Description = "Elektronik och tekniska produkter" },
                new Category { CategoryId = 2, Name = "Home & Kitchen", Description = "Produkter för hemmet och köket" },
                new Category { CategoryId = 3, Name = "Clothing", Description = "Kläder och accessoarer" },
                new Category { CategoryId = 4, Name = "Sports", Description = "Sportutrustning och träningsprodukter" },
                new Category { CategoryId = 5, Name = "Books", Description = "Böcker och litteratur" }
                );

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierId = 1, Name = "TechVision AB", ContactPerson = "Anna Lindberg", 
                    Email = "anna@techvision.se", Phone = "070-123-4567" },
                new Supplier { SupplierId = 2, Name = "HomeStyle", ContactPerson = "Johan Bergman", 
                    Email = "johan@homestyle.se", Phone = "073-234-5678" },
                new Supplier { SupplierId = 3, Name = "Fashion First", ContactPerson = "Maria Ek", 
                    Email = "maria@fashionfirst.se", Phone = "076-345-6789" },
                new Supplier { SupplierId = 4, Name = "SportMax", ContactPerson = "Erik Strand", 
                    Email = "erik@sportmax.se", Phone = "072-456-7890" },
                new Supplier { SupplierId = 5, Name = "Nordic Electronics", ContactPerson = "Karl Holm", 
                    Email = "karl@nordicelec.se", Phone = "070-567-8901" },
                new Supplier { SupplierId = 6, Name = "Global Gadgets", ContactPerson = "Lisa Björk",
                    Email = "lisa@globalgadgets.se", Phone = "073-678-9012" }
                );

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, OrderDate = new DateTime(2025, 03, 01), CustomerId = 1, TotalAmount = 11999, Status = "Levererad" },
                new Order { OrderId = 2, OrderDate = new DateTime(2025, 03, 05), CustomerId = 2, TotalAmount = 9798, Status = "Levererad "},
                new Order { OrderId = 3, OrderDate = new DateTime(2025, 03, 10), CustomerId = 3, TotalAmount = 18999, Status = "Behandlas" },
                new Order { OrderId = 4, OrderDate = new DateTime(2025, 03, 12), CustomerId = 4, TotalAmount = 3499, Status = "Levererad" },
                new Order { OrderId = 5, OrderDate = new DateTime(2025, 03, 15), CustomerId = 5, TotalAmount = 16994, Status = "Skickad" },
                new Order { OrderId = 6, OrderDate = new DateTime(2025, 02, 20), CustomerId = 1, TotalAmount = 899, Status = "Levererad" },
                new Order { OrderId = 7, OrderDate = new DateTime(2025, 02, 25), CustomerId = 3, TotalAmount = 2498, Status = "Levererad" },
                new Order { OrderId = 8, OrderDate = new DateTime(2025, 03, 18), CustomerId = 2, TotalAmount = 1598, Status = "Skickad" },
                new Order { OrderId = 9, OrderDate = new DateTime(2025, 03, 20), CustomerId = 4, TotalAmount = 5794, Status = "Behandlas" },
                new Order { OrderId = 10, OrderDate = new DateTime(2025, 03, 22), CustomerId = 5, TotalAmount = 1299, Status = "Behandlas" }
                );

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { OrderDetailId = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 11999 },
                new OrderDetail { OrderDetailId = 2, OrderId = 2, ProductId = 3, Quantity = 2, UnitPrice = 3499 },
                new OrderDetail { OrderDetailId = 3, OrderId = 2, ProductId = 13, Quantity = 3, UnitPrice = 899 },
                new OrderDetail { OrderDetailId = 4, OrderId = 3, ProductId = 11, Quantity = 1, UnitPrice = 18999 },
                new OrderDetail { OrderDetailId = 5, OrderId = 4, ProductId = 3, Quantity = 1, UnitPrice = 3499 },
                new OrderDetail { OrderDetailId = 6, OrderId = 5, ProductId = 4, Quantity = 1, UnitPrice = 12499 },
                new OrderDetail { OrderDetailId = 7, OrderId = 5, ProductId = 5, Quantity = 1, UnitPrice = 4495 },
                new OrderDetail { OrderDetailId = 8, OrderId = 6, ProductId = 13, Quantity = 1, UnitPrice = 899 },
                new OrderDetail { OrderDetailId = 9, OrderId = 7, ProductId = 8, Quantity = 1, UnitPrice = 1499 },
                new OrderDetail { OrderDetailId = 10, OrderId = 7, ProductId = 9, Quantity = 3, UnitPrice = 349 },
                new OrderDetail { OrderDetailId = 11, OrderId = 8, ProductId = 7, Quantity = 1, UnitPrice = 1999 },
                new OrderDetail { OrderDetailId = 12, OrderId = 8, ProductId = 15, Quantity = 3, UnitPrice = 499 },
                new OrderDetail { OrderDetailId = 13, OrderId = 9, ProductId = 2, Quantity = 1, UnitPrice = 8999 },
                new OrderDetail { OrderDetailId = 14, OrderId = 9, ProductId = 6, Quantity = 1, UnitPrice = 1299 },
                new OrderDetail { OrderDetailId = 15, OrderId = 9, ProductId = 14, Quantity = 2, UnitPrice = 799 },
                new OrderDetail { OrderDetailId = 16, OrderId = 10, ProductId = 6, Quantity = 1, UnitPrice = 1299 }
                );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, Name = "Anders Svensson", Email = "anders@example.com", Phone = "070-111-2233", Address = "Storgatan 1, Stockholm" },
                new Customer { CustomerId = 2, Name = "Emma Johansson", Email = "emma@example.com", Phone = "073-222-3344", Address = "Kungsgatan 15, Göteborg" },
                new Customer { CustomerId = 3, Name = "Lars Nilsson", Email = "lars@example.com", Phone = "076-333-4455", Address = "Drottninggatan 8, Malmö" },
                new Customer { CustomerId = 4, Name = "Sofia Lindgren", Email = "sofia@example.com", Phone = "072-444-5566", Address = "Sveavägen 22, Uppsala" },
                new Customer { CustomerId = 5, Name = "Peter Karlsson", Email = "peter@example.com", Phone = "070-555-6677", Address = "Järntorget 5, Göteborg" }
                );

        }
    }
}
