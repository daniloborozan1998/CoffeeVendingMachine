using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeVendingMachine.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingridients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Coffee",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 15f);

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 20f);

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 25f);

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 25f);

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 30f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingridients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Coffee",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 1,
                column: "Price",
                value: 15m);

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 20m);

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 25m);

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 25m);

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 5,
                column: "Price",
                value: 30m);
        }
    }
}
