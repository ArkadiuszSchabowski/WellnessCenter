using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellnessCenterBackend.Migrations
{
    /// <inheritdoc />
    public partial class RelationEntityBookingAndMassageName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "MassageNameId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MassageNameId",
                table: "Bookings",
                column: "MassageNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_MassageNames_MassageNameId",
                table: "Bookings",
                column: "MassageNameId",
                principalTable: "MassageNames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_MassageNames_MassageNameId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_MassageNameId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "MassageNameId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
