using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestionZapatillas.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrimerMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SizeNumber = table.Column<decimal>(type: "decimal(3,1)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.SizeId);
                });

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    SportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SportName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.SportId);
                });

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    ShoeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.ShoeId);
                    table.ForeignKey(
                        name: "FK_Shoes_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shoes_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shoes_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "SportId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoeSizes",
                columns: table => new
                {
                    ShoeSizeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShoeId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoeSizes", x => x.ShoeSizeId);
                    table.ForeignKey(
                        name: "FK_ShoeSizes_Shoes_ShoeId",
                        column: x => x.ShoeId,
                        principalTable: "Shoes",
                        principalColumn: "ShoeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoeSizes_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Active", "BrandName", "Country" },
                values: new object[,]
                {
                    { 1, true, "Adidas", "Alemania" },
                    { 2, true, "Nike", "Estados Unidos" },
                    { 3, true, "Topper", "Argentina" },
                    { 4, true, "Reebok", "Estados Unidos" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Active", "GenreName" },
                values: new object[,]
                {
                    { 1, true, "Masculino" },
                    { 2, true, "Femenino" },
                    { 3, true, "Unisex" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "SizeId", "Active", "SizeNumber" },
                values: new object[,]
                {
                    { 1, true, 28.0m },
                    { 2, true, 28.5m },
                    { 3, true, 29.0m },
                    { 4, true, 29.5m },
                    { 5, true, 30.0m },
                    { 6, true, 30.5m },
                    { 7, true, 31.0m },
                    { 8, true, 31.5m },
                    { 9, true, 32.0m },
                    { 10, true, 32.5m },
                    { 11, true, 33.0m },
                    { 12, true, 33.5m },
                    { 13, true, 34.0m },
                    { 14, true, 34.5m },
                    { 15, true, 35.0m },
                    { 16, true, 35.5m },
                    { 17, true, 36.0m },
                    { 18, true, 36.5m },
                    { 19, true, 37.0m },
                    { 20, true, 37.5m },
                    { 21, true, 38.0m },
                    { 22, true, 38.5m },
                    { 23, true, 39.0m },
                    { 24, true, 39.5m },
                    { 25, true, 40.0m },
                    { 26, true, 40.5m },
                    { 27, true, 41.0m },
                    { 28, true, 41.5m },
                    { 29, true, 42.0m },
                    { 30, true, 42.5m },
                    { 31, true, 43.0m },
                    { 32, true, 43.5m },
                    { 33, true, 44.0m },
                    { 34, true, 44.5m },
                    { 35, true, 45.0m },
                    { 36, true, 45.5m },
                    { 37, true, 46.0m },
                    { 38, true, 46.5m },
                    { 39, true, 47.0m },
                    { 40, true, 47.5m },
                    { 41, true, 48.0m },
                    { 42, true, 48.5m },
                    { 43, true, 49.0m },
                    { 44, true, 49.5m },
                    { 45, true, 50.0m },
                    { 46, true, 50.5m }
                });

            migrationBuilder.InsertData(
                table: "Sports",
                columns: new[] { "SportId", "Active", "SportName" },
                values: new object[,]
                {
                    { 1, true, "Fútbol" },
                    { 2, true, "Running" },
                    { 3, true, "Outdoor" },
                    { 4, true, "Urban" },
                    { 5, true, "Training" },
                    { 6, true, "Tenis" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brands_BrandName",
                table: "Brands",
                column: "BrandName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreName",
                table: "Genres",
                column: "GenreName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_BrandId",
                table: "Shoes",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_GenreId",
                table: "Shoes",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_SportId",
                table: "Shoes",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSizes_ShoeId_SizeId",
                table: "ShoeSizes",
                columns: new[] { "ShoeId", "SizeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoeSizes_SizeId",
                table: "ShoeSizes",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SizeNumber",
                table: "Sizes",
                column: "SizeNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sports_SportName",
                table: "Sports",
                column: "SportName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoeSizes");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Sports");
        }
    }
}
