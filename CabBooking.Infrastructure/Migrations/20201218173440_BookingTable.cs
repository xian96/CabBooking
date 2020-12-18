using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CabBooking.Infrastructure.Migrations
{
    public partial class BookingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CabType",
                columns: table => new
                {
                    CabTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CabTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabType", x => x.CabTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    PlaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.PlaceId);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BookingTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FromPlaceId = table.Column<int>(type: "int", nullable: true),
                    ToPlaceId = table.Column<int>(type: "int", nullable: true),
                    PickupAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PickupTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    CabTypeId = table.Column<int>(type: "int", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_CabType_CabTypeId",
                        column: x => x.CabTypeId,
                        principalTable: "CabType",
                        principalColumn: "CabTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Place_FromPlaceId",
                        column: x => x.FromPlaceId,
                        principalTable: "Place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Place_ToPlaceId",
                        column: x => x.ToPlaceId,
                        principalTable: "Place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CabTypeId",
                table: "Booking",
                column: "CabTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_FromPlaceId",
                table: "Booking",
                column: "FromPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ToPlaceId",
                table: "Booking",
                column: "ToPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "CabType");

            migrationBuilder.DropTable(
                name: "Place");
        }
    }
}
