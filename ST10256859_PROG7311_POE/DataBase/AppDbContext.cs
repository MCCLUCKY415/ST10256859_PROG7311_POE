// Dhiren Ruthenavelu
// ST10256859
// Group 2

// References:
// - GitHub Copilot for assisting with the structure of the code.
// - ChatGPT for assisting me with finding and fixing errors in the code.

using Microsoft.EntityFrameworkCore;
using ST10256859_PROG7311_POE.Models;

namespace ST10256859_PROG7311_POE.DataBase
{
    // Entity Framework Core database context
    public class AppDbContext : DbContext
    {
        // DbSets for each entity
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Constructor with options
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // Configures the model and seeds initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Farmers
            modelBuilder.Entity<Farmer>().HasData(
                new Farmer { FarmerID = 1, FirstName = "Dhiren", LastName = "Ruthenavelu", PhoneNumber = "1234567899", Address = "65 Ringwood Drive", Email = "dhiren@gmail.com", Password = "password123" },
                new Farmer { FarmerID = 2, FirstName = "Chad", LastName = "Fairlie", PhoneNumber = "2137465899", Address = "456 Oak Avenue", Email = "chad@gmail.com", Password = "password123" },
                new Farmer { FarmerID = 3, FirstName = "Ava", LastName = "Smith", PhoneNumber = "3216549870", Address = "789 Pine Street", Email = "ava@gmail.com", Password = "password123" },
                new Farmer { FarmerID = 4, FirstName = "Liam", LastName = "Johnson", PhoneNumber = "9876543210", Address = "101 Maple Lane", Email = "liam@gmail.com", Password = "password123" },
                new Farmer { FarmerID = 5, FirstName = "Olivia", LastName = "Williams", PhoneNumber = "5551234567", Address = "202 Cedar Road", Email = "olivia@gmail.com", Password = "password123" },
                new Farmer { FarmerID = 6, FirstName = "Noah", LastName = "Brown", PhoneNumber = "4449876543", Address = "303 Birch Blvd", Email = "noah@gmail.com", Password = "password123" },
                new Farmer { FarmerID = 7, FirstName = "Emma", LastName = "Jones", PhoneNumber = "3334567890", Address = "404 Spruce Ave", Email = "emma@gmail.com", Password = "password123" },
                new Farmer { FarmerID = 8, FirstName = "Mason", LastName = "Davis", PhoneNumber = "2223456789", Address = "505 Willow Way", Email = "mason@gmail.com", Password = "password123" }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, FirstName = "Jenna", LastName = "Kemm", PhoneNumber = "1234567899", Address = "13 Nautilis Drive", Email = "jenna@gmail.com", Password = "password123" },
                new Employee { EmployeeID = 2, FirstName = "Kayla", LastName = "Ferr", PhoneNumber = "1001001000", Address = "14 Jumper Drive", Email = "kayla@gmail.com", Password = "password123" },
                new Employee { EmployeeID = 3, FirstName = "Lucas", LastName = "Miller", PhoneNumber = "1112223333", Address = "15 Ocean Drive", Email = "lucas@gmail.com", Password = "password123" },
                new Employee { EmployeeID = 4, FirstName = "Sophia", LastName = "Wilson", PhoneNumber = "2223334444", Address = "16 River Road", Email = "sophia@gmail.com", Password = "password123" },
                new Employee { EmployeeID = 5, FirstName = "Ethan", LastName = "Moore", PhoneNumber = "3334445555", Address = "17 Forest Lane", Email = "ethan@gmail.com", Password = "password123" },
                new Employee { EmployeeID = 6, FirstName = "Isabella", LastName = "Taylor", PhoneNumber = "4445556666", Address = "18 Mountain Ave", Email = "isabella@gmail.com", Password = "password123" },
                new Employee { EmployeeID = 7, FirstName = "Aiden", LastName = "Anderson", PhoneNumber = "5556667777", Address = "19 Valley Blvd", Email = "aiden@gmail.com", Password = "password123" },
                new Employee { EmployeeID = 8, FirstName = "Mia", LastName = "Thomas", PhoneNumber = "6667778888", Address = "20 Lake Street", Email = "mia@gmail.com", Password = "password123" }
            );

            // Seed Products (2 per farmer)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, ProductName = "Tomatoes", Category = "Vegetable", ProductionDate = new DateTime(2025, 3, 1), ProductPrice = 15.99m, AvailableQuantity = 50, Description = "Fresh and ripe tomatoes.", FarmerID = 1, ProductImage = null },
                new Product { ProductID = 2, ProductName = "Carrots", Category = "Vegetable", ProductionDate = new DateTime(2025, 4, 1), ProductPrice = 10.50m, AvailableQuantity = 80, Description = "Crunchy orange carrots.", FarmerID = 1, ProductImage = null },
                new Product { ProductID = 3, ProductName = "Apples", Category = "Fruit", ProductionDate = new DateTime(2025, 5, 1), ProductPrice = 20.00m, AvailableQuantity = 100, Description = "Sweet red apples.", FarmerID = 2, ProductImage = null },
                new Product { ProductID = 4, ProductName = "Lettuce", Category = "Vegetable", ProductionDate = new DateTime(2025, 2, 15), ProductPrice = 8.75m, AvailableQuantity = 40, Description = "Crisp green lettuce.", FarmerID = 2, ProductImage = null },
                new Product { ProductID = 5, ProductName = "Potatoes", Category = "Vegetable", ProductionDate = new DateTime(2025, 3, 10), ProductPrice = 12.00m, AvailableQuantity = 60, Description = "Organic potatoes.", FarmerID = 3, ProductImage = null },
                new Product { ProductID = 6, ProductName = "Strawberries", Category = "Fruit", ProductionDate = new DateTime(2025, 4, 12), ProductPrice = 25.00m, AvailableQuantity = 30, Description = "Juicy strawberries.", FarmerID = 3, ProductImage = null },
                new Product { ProductID = 7, ProductName = "Cucumbers", Category = "Vegetable", ProductionDate = new DateTime(2025, 5, 5), ProductPrice = 9.50m, AvailableQuantity = 70, Description = "Fresh cucumbers.", FarmerID = 4, ProductImage = null },
                new Product { ProductID = 8, ProductName = "Blueberries", Category = "Fruit", ProductionDate = new DateTime(2025, 6, 1), ProductPrice = 30.00m, AvailableQuantity = 25, Description = "Wild blueberries.", FarmerID = 4, ProductImage = null },
                new Product { ProductID = 9, ProductName = "Peppers", Category = "Vegetable", ProductionDate = new DateTime(2025, 3, 20), ProductPrice = 14.00m, AvailableQuantity = 55, Description = "Colorful peppers.", FarmerID = 5, ProductImage = null },
                new Product { ProductID = 10, ProductName = "Bananas", Category = "Fruit", ProductionDate = new DateTime(2025, 4, 22), ProductPrice = 18.00m, AvailableQuantity = 90, Description = "Sweet bananas.", FarmerID = 5, ProductImage = null },
                new Product { ProductID = 11, ProductName = "Spinach", Category = "Vegetable", ProductionDate = new DateTime(2025, 5, 15), ProductPrice = 11.00m, AvailableQuantity = 35, Description = "Leafy spinach.", FarmerID = 6, ProductImage = null },
                new Product { ProductID = 12, ProductName = "Oranges", Category = "Fruit", ProductionDate = new DateTime(2025, 6, 10), ProductPrice = 22.00m, AvailableQuantity = 65, Description = "Citrus oranges.", FarmerID = 6, ProductImage = null },
                new Product { ProductID = 13, ProductName = "Broccoli", Category = "Vegetable", ProductionDate = new DateTime(2025, 3, 25), ProductPrice = 13.00m, AvailableQuantity = 45, Description = "Green broccoli.", FarmerID = 7, ProductImage = null },
                new Product { ProductID = 14, ProductName = "Grapes", Category = "Fruit", ProductionDate = new DateTime(2025, 4, 28), ProductPrice = 28.00m, AvailableQuantity = 75, Description = "Seedless grapes.", FarmerID = 7, ProductImage = null },
                new Product { ProductID = 15, ProductName = "Onions", Category = "Vegetable", ProductionDate = new DateTime(2025, 5, 18), ProductPrice = 7.50m, AvailableQuantity = 85, Description = "Red onions.", FarmerID = 8, ProductImage = null },
                new Product { ProductID = 16, ProductName = "Pears", Category = "Fruit", ProductionDate = new DateTime(2025, 6, 15), ProductPrice = 19.00m, AvailableQuantity = 60, Description = "Juicy pears.", FarmerID = 8, ProductImage = null }
            );
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------
    }
}