using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dive_deep.Migrations
{
    /// <inheritdoc />
    public partial class cartBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingItem_CartBookings_CartBookingId",
                table: "BookingItem");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CartBookings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CartBookingId",
                table: "BookingItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartBookings_UserId",
                table: "CartBookings",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingItem_CartBookings_CartBookingId",
                table: "BookingItem",
                column: "CartBookingId",
                principalTable: "CartBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartBookings_AspNetUsers_UserId",
                table: "CartBookings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingItem_CartBookings_CartBookingId",
                table: "BookingItem");

            migrationBuilder.DropForeignKey(
                name: "FK_CartBookings_AspNetUsers_UserId",
                table: "CartBookings");

            migrationBuilder.DropIndex(
                name: "IX_CartBookings_UserId",
                table: "CartBookings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CartBookings");

            migrationBuilder.AlterColumn<int>(
                name: "CartBookingId",
                table: "BookingItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingItem_CartBookings_CartBookingId",
                table: "BookingItem",
                column: "CartBookingId",
                principalTable: "CartBookings",
                principalColumn: "Id");
        }
    }
}
