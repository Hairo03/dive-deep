using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dive_deep.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerDay = table.Column<double>(type: "float", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thickness = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PackageProduct",
                columns: table => new
                {
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageProduct", x => new { x.PackageId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_PackageProduct_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "Name", "PricePerDay" },
                values: new object[,]
                {
                    { 1, "Komplet Dykkersæt", 900.0 },
                    { 2, "Snorkelsæt", 300.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CategoryType", "Gender", "Name", "PricePerDay", "Size", "Thickness" },
                values: new object[,]
                {
                    { 1, "Scubapro", 0, "Unisex", "Navigator Lite BCD", 125.0, "M", "2mm" },
                    { 2, "Scubapro", 0, "Unisex", "BCD Glide", 100.0, "S", "4mm" },
                    { 3, "Scubapro", 2, "Unisex", "Definition", 100.0, "L", "5mm" },
                    { 4, "Scubapro", 6, "Unisex", "5 liter tank", 150.0, "M", "2mm" },
                    { 5, "Subapro", 1, "Unisex", "MK25EVO", 125.0, "M", "2mm" },
                    { 6, "Scubapro", 2, "Unisex", "Ghost", 50.0, "M", "2mm" },
                    { 7, "Seac", 3, "Unisex", "ALA", 50.0, "M", "2mm" },
                    { 8, "Cressi", 4, "Unisex", "F1", 50.0, "M", "2mm" },
                    { 9, "Cressi", 5, "Unisex", "Snorkel", 25.0, "M", "2mm" }
                });

            migrationBuilder.InsertData(
                table: "PackageProduct",
                columns: new[] { "PackageId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 8 },
                    { 2, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageProduct_ProductId",
                table: "PackageProduct",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageProduct");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
