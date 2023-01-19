using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeVendingMachine.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newcoffee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Coffee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 1,
                column: "Images",
                value: "./Images/espresso.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 2,
                column: "Images",
                value: "./Images/macchiato.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 3,
                column: "Images",
                value: "./Images/americano.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 4,
                column: "Images",
                value: "./Images/latte.jpg");

            migrationBuilder.UpdateData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 5,
                column: "Images",
                value: "./Images/capuccino1.jpg");

            migrationBuilder.InsertData(
                table: "Coffee",
                columns: new[] { "Id", "CoffeeTypeName", "Images", "Price" },
                values: new object[] { 6, "Irish", "./Images/irish.jpg", 30f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coffee",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Images",
                table: "Coffee");
        }
    }
}
