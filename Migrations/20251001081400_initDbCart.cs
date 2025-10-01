using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dive_deep.Migrations
{
    /// <inheritdoc />
    public partial class initDbCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CartBookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CartBookings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
