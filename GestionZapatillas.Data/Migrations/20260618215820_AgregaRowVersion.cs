using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionZapatillas.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregaRowVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Sports",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Sizes",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Brands",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Brands");
        }
    }
}
