using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoffeeVendingMachine.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addnewcoffee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewModernCoffee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoffeeTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewModernCoffee", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "NewModernCoffee",
                columns: new[] { "Id", "CoffeeTypeName", "Images", "Price" },
                values: new object[,]
                {
                    { 1, "Frappe", "./Images/frappe.jpg", 40f },
                    { 2, "Glace", "./Images/lglace.jpg", 35f },
                    { 3, "Mocha", "./Images/mocha.jpg", 25f },
                    { 4, "Chocolate", "./Images/chocolate.jpg", 25f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewModernCoffee");
        }
    }
}
