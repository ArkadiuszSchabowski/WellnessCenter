using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WellnessCenterBackend.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "HashPassword", "LastName", "Login", "Phone", "RoleId" },
                values: new object[,]
                {
                    { 1, "zajączek@o2.pl", "Dominika", "12345", "Zając", "Dominika123", "500-600-700", 1 },
                    { 2, "młyniok@o2.pl", "Paulina", "23456", "Młyniok", "Paulina123", "501-601-701", 2 },
                    { 3, "szum@o2.pl", "Renata", "34567", "Szum", "Renata123", "502-602-702", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
