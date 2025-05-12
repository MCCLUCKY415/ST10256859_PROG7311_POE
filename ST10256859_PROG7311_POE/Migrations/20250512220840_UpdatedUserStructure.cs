using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ST10256859_PROG7311_POE.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Farmers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "ContactNumber",
                table: "Employees",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Farmers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Farmers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 1,
                columns: new[] { "Address", "Email", "Password" },
                values: new object[] { "13 Nautilis Drive", "jenna@gmail.com", "password123" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 2,
                columns: new[] { "Address", "Email", "LastName", "Password" },
                values: new object[] { "14 Jumper Drive", "kayla@gmail.com", "Ferr", "password123" });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "dhiren@gmail.com", "password123" });

            migrationBuilder.UpdateData(
                table: "Farmers",
                keyColumn: "FarmerID",
                keyValue: 2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "chad@gmail.com", "password123" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Farmers");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Farmers",
                newName: "ContactNumber");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Employees",
                newName: "ContactNumber");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeID = table.Column<int>(type: "INTEGER", nullable: true),
                    FarmerID = table.Column<int>(type: "INTEGER", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_Users_Farmers_FarmerID",
                        column: x => x.FarmerID,
                        principalTable: "Farmers",
                        principalColumn: "FarmerID");
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeID",
                keyValue: 2,
                column: "LastName",
                value: "F");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "EmployeeID", "FarmerID", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "dhiren@gmail.com", null, 1, "password123", "Farmer" },
                    { 2, "chad@gmail.com", null, 2, "password123", "Farmer" },
                    { 3, "jenna@gmail.com", 1, null, "password123", "Employee" },
                    { 4, "kayla@gmail.com", 2, null, "password123", "Employee" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeID",
                table: "Users",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FarmerID",
                table: "Users",
                column: "FarmerID");
        }
    }
}
