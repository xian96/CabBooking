using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CabBooking.Infrastructure.Migrations
{
    public partial class BookingHistoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingHistory",
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
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    CompTime = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Charge = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FeedBack = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingHistory_CabType_CabTypeId",
                        column: x => x.CabTypeId,
                        principalTable: "CabType",
                        principalColumn: "CabTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingHistory_Place_FromPlaceId",
                        column: x => x.FromPlaceId,
                        principalTable: "Place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BookingHistory_Place_ToPlaceId",
                        column: x => x.ToPlaceId,
                        principalTable: "Place",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistory_CabTypeId",
                table: "BookingHistory",
                column: "CabTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistory_FromPlaceId",
                table: "BookingHistory",
                column: "FromPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingHistory_ToPlaceId",
                table: "BookingHistory",
                column: "ToPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingHistory");
        }
    }
}
