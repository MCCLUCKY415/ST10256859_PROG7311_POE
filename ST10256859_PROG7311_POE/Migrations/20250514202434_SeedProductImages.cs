using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ST10256859_PROG7311_POE.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeID", "Address", "Email", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 3, "15 Ocean Drive", "lucas@gmail.com", "Lucas", "Miller", "password123", "1112223333" },
                    { 4, "16 River Road", "sophia@gmail.com", "Sophia", "Wilson", "password123", "2223334444" },
                    { 5, "17 Forest Lane", "ethan@gmail.com", "Ethan", "Moore", "password123", "3334445555" },
                    { 6, "18 Mountain Ave", "isabella@gmail.com", "Isabella", "Taylor", "password123", "4445556666" },
                    { 7, "19 Valley Blvd", "aiden@gmail.com", "Aiden", "Anderson", "password123", "5556667777" },
                    { 8, "20 Lake Street", "mia@gmail.com", "Mia", "Thomas", "password123", "6667778888" }
                });

            migrationBuilder.InsertData(
                table: "Farmers",
                columns: new[] { "FarmerID", "Address", "Email", "FirstName", "LastName", "Password", "PhoneNumber" },
                values: new object[,]
                {
                    { 3, "789 Pine Street", "ava@gmail.com", "Ava", "Smith", "password123", "3216549870" },
                    { 4, "101 Maple Lane", "liam@gmail.com", "Liam", "Johnson", "password123", "9876543210" },
                    { 5, "202 Cedar Road", "olivia@gmail.com", "Olivia", "Williams", "password123", "5551234567" },
                    { 6, "303 Birch Blvd", "noah@gmail.com", "Noah", "Brown", "password123", "4449876543" },
                    { 7, "404 Spruce Ave", "emma@gmail.com", "Emma", "Jones", "password123", "3334567890" },
                    { 8, "505 Willow Way", "mason@gmail.com", "Mason", "Davis", "password123", "2223456789" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "AvailableQuantity", "Category", "Description", "FarmerID", "ProductImage", "ProductName", "ProductPrice", "ProductionDate" },
                values: new object[,]
                {
                    { 5, 60, "Vegetable", "Organic potatoes.", 3, null, "Potatoes", 12.00m, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 30, "Fruit", "Juicy strawberries.", 3, null, "Strawberries", 25.00m, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 70, "Vegetable", "Fresh cucumbers.", 4, null, "Cucumbers", 9.50m, new DateTime(2025, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 25, "Fruit", "Wild blueberries.", 4, null, "Blueberries", 30.00m, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 55, "Vegetable", "Colorful peppers.", 5, null, "Peppers", 14.00m, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 90, "Fruit", "Sweet bananas.", 5, null, "Bananas", 18.00m, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 35, "Vegetable", "Leafy spinach.", 6, null, "Spinach", 11.00m, new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 65, "Fruit", "Citrus oranges.", 6, null, "Oranges", 22.00m, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 45, "Vegetable", "Green broccoli.", 7, null, "Broccoli", 13.00m, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 75, "Fruit", "Seedless grapes.", 7, null, "Grapes", 28.00m, new DateTime(2025, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 85, "Vegetable", "Red onions.", 8, null, "Onions", 7.50m, new DateTime(2025, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 60, "Fruit", "Juicy pears.", 8, null, "Pears", 19.00m, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 8);
        }
    }
}
