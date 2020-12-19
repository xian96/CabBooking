using Microsoft.EntityFrameworkCore.Migrations;

namespace CabBooking.Infrastructure.Migrations
{
    public partial class AddCabTypenavigatoinToBookingAndHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CabTypeId1",
                table: "BookingHistory",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CabTypeId1",
                table: "Booking",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistory_CabTypeId1",
                table: "BookingHistory",
                column: "CabTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CabTypeId1",
                table: "Booking",
                column: "CabTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_CabType_CabTypeId1",
                table: "Booking",
                column: "CabTypeId1",
                principalTable: "CabType",
                principalColumn: "CabTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHistory_CabType_CabTypeId1",
                table: "BookingHistory",
                column: "CabTypeId1",
                principalTable: "CabType",
                principalColumn: "CabTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_CabType_CabTypeId1",
                table: "Booking");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingHistory_CabType_CabTypeId1",
                table: "BookingHistory");

            migrationBuilder.DropIndex(
                name: "IX_BookingHistory_CabTypeId1",
                table: "BookingHistory");

            migrationBuilder.DropIndex(
                name: "IX_Booking_CabTypeId1",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CabTypeId1",
                table: "BookingHistory");

            migrationBuilder.DropColumn(
                name: "CabTypeId1",
                table: "Booking");
        }
    }
}
