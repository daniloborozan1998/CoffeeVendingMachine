using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeVendingMachine.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addnewcoffee1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NewModernCoffee",
                keyColumn: "Id",
                keyValue: 2,
                column: "Images",
                value: "./Images/glace.jpg");

            migrationBuilder.UpdateData(
                table: "NewModernCoffee",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CoffeeTypeName", "Images" },
                values: new object[] { "Romano", "./Images/romano.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NewModernCoffee",
                keyColumn: "Id",
                keyValue: 2,
                column: "Images",
                value: "./Images/lglace.jpg");

            migrationBuilder.UpdateData(
                table: "NewModernCoffee",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CoffeeTypeName", "Images" },
                values: new object[] { "Chocolate", "./Images/chocolate.jpg" });
        }
    }
}
