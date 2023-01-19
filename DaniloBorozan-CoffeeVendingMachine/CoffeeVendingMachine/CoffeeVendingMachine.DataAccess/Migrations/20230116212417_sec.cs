using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeVendingMachine.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class sec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CoffeeTypeName",
                table: "Coffee",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoffeeTypeName",
                value: "Espresso");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 2,
                column: "CoffeeTypeName",
                value: "Macchiato");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 3,
                column: "CoffeeTypeName",
                value: "Americano");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 4,
                column: "CoffeeTypeName",
                value: "Latte");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 5,
                column: "CoffeeTypeName",
                value: "Cappuccino");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CoffeeTypeName",
                table: "Coffee",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 1,
                column: "CoffeeTypeName",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 2,
                column: "CoffeeTypeName",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 3,
                column: "CoffeeTypeName",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 4,
                column: "CoffeeTypeName",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 5,
                column: "CoffeeTypeName",
                value: 5);
        }
    }
}
