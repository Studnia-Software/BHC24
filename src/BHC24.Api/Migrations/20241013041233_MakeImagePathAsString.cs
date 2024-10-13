using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHC24.Api.Migrations
{
    /// <inheritdoc />
    public partial class MakeImagePathAsString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Tags");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Tags",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Tags");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Tags",
                type: "BLOB",
                nullable: true);
        }
    }
}
