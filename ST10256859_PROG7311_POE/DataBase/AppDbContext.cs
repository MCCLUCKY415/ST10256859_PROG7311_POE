using Microsoft.EntityFrameworkCore;
using ST10256859_PROG7311_POE.Models;

namespace ST10256859_PROG7311_POE.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Farmers
            modelBuilder.Entity<Farmer>().HasData(
                new Farmer { FarmerID = 1, FirstName = "Dhiren", LastName = "Ruthenavelu", PhoneNumber = "1234567899", Address = "65 Ringwood Drive", Email = "dhiren@gmail.com", Password = "password123" },
                new Farmer { FarmerID = 2, FirstName = "Chad", LastName = "Fairlie", PhoneNumber = "2137465899", Address = "456 Oak Avenue", Email = "chad@gmail.com", Password = "password123" }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, FirstName = "Jenna", LastName = "Kemm", PhoneNumber = "1234567899", Address = "13 Nautilis Drive", Email = "jenna@gmail.com", Password = "password123" },
                new Employee { EmployeeID = 2, FirstName = "Kayla", LastName = "Ferr", PhoneNumber = "1001001000", Address = "14 Jumper Drive", Email = "kayla@gmail.com", Password = "password123" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, ProductName = "Tomatoes", Category = "Vegetable", ProductionDate = new DateTime(2025, 3, 1), ProductPrice = 15.99m, AvailableQuantity = 50, Description = "Fresh and ripe tomatoes.", FarmerID = 1, ProductImage = null },
                new Product { ProductID = 2, ProductName = "Carrots", Category = "Vegetable", ProductionDate = new DateTime(2025, 4, 1), ProductPrice = 10.50m, AvailableQuantity = 80, Description = "Crunchy orange carrots.", FarmerID = 1, ProductImage = null },
                new Product { ProductID = 3, ProductName = "Apples", Category = "Fruit", ProductionDate = new DateTime(2025, 5, 1), ProductPrice = 20.00m, AvailableQuantity = 100, Description = "Sweet red apples.", FarmerID = 2, ProductImage = null },
                new Product { ProductID = 4, ProductName = "Lettuce", Category = "Vegetable", ProductionDate = new DateTime(2025, 2, 15), ProductPrice = 8.75m, AvailableQuantity = 40, Description = "Crisp green lettuce.", FarmerID = 2, ProductImage = null }
            );
        }
    }
}