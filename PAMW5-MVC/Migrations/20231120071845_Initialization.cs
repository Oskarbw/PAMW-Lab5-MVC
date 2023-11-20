using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PAMW5_MVC.Migrations
{
    /// <inheritdoc />
    public partial class Initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parcels",
                columns: new[] { "Id", "Receiver", "Sender", "Weight" },
                values: new object[,]
                {
                    { 1, "Frank", "John", 12 },
                    { 2, "Hilary", "Janice", 17 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parcels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parcels",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
