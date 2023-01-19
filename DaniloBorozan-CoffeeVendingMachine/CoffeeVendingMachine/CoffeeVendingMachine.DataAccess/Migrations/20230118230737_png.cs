using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeVendingMachine.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class png : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NewModernCoffee",
                keyColumn: "Id",
                keyValue: 1,
                column: "Images",
                value: "./Images/frappe.png");

            migrationBuilder.UpdateData(
                table: "NewModernCoffee",
                keyColumn: "Id",
                keyValue: 2,
                column: "Images",
                value: "./Images/glace.png");

            migrationBuilder.UpdateData(
                table: "NewModernCoffee",
                keyColumn: "Id",
                keyValue: 3,
                column: "Images",
                value: "./Images/mocha.png");

            migrationBuilder.UpdateData(
                table: "NewModernCoffee",
                keyColumn: "Id",
                keyValue: 4,
                column: "Images",
                value: "./Images/romano.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NewModernCoffee",
                keyColumn: "Id",
                keyValue: 1,
                column: "Images",
                value: "./Images/frappe.jpg");

            migrationBuilder.UpdateData(
                table: "NewModernCoffee",
                keyColumn: "Id",
                keyValue: 2,
                column: "Images",
                value: "./Images/glace.jpg");

            migrationBuilder.UpdateData(
                table: "NewModernCoffee",
                keyColumn: "Id",
                keyValue: 3,
                column: "Images",
                value: "./Images/mocha.jpg");

            migrationBuilder.UpdateData(
                table: "NewModernCoffee",
                keyColumn: "Id",
                keyValue: 4,
                column: "Images",
                value: "./Images/romano.jpg");
        }
    }
}
