using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dive_deep.Migrations
{
    /// <inheritdoc />
    public partial class CartbookingAndLogin1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BookingItem",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BookingItem_UserId",
                table: "BookingItem",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingItem_AspNetUsers_UserId",
                table: "BookingItem",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingItem_AspNetUsers_UserId",
                table: "BookingItem");

            migrationBuilder.DropIndex(
                name: "IX_BookingItem_UserId",
                table: "BookingItem");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BookingItem");

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PackageId",
                table: "Booking",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ProductId",
                table: "Booking",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_UserId",
                table: "Booking",
                column: "UserId");
        }
    }
}
