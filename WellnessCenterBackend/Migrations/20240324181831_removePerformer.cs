using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellnessCenterBackend.Migrations
{
    /// <inheritdoc />
    public partial class removePerformer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Performer",
                table: "MassageNames");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Performer",
                table: "MassageNames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MassageNames",
                keyColumn: "Id",
                keyValue: 1,
                column: "Performer",
                value: 2);

            migrationBuilder.UpdateData(
                table: "MassageNames",
                keyColumn: "Id",
                keyValue: 2,
                column: "Performer",
                value: 1);

            migrationBuilder.UpdateData(
                table: "MassageNames",
                keyColumn: "Id",
                keyValue: 3,
                column: "Performer",
                value: 3);
        }
    }
}
