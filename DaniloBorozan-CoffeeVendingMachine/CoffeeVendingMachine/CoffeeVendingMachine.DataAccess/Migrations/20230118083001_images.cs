using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeVendingMachine.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 5,
                column: "Images",
                value: "./Images/cappuccino.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 5,
                column: "Images",
                value: "./Images/capuccino1.jpg");
        }
    }
}
