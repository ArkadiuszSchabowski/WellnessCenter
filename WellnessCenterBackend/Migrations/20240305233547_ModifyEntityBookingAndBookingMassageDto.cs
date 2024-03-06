using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WellnessCenterBackend.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEntityBookingAndBookingMassageDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "isPaid",
                table: "Bookings",
                newName: "IsPaid");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BookingDay",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BookingHour",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingDay",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingHour",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "Bookings",
                newName: "isPaid");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
