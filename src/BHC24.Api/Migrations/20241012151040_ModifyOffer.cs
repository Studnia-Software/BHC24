using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHC24.Api.Migrations
{
    /// <inheritdoc />
    public partial class ModifyOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Offers_OfferId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OfferId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OfferId",
                table: "AspNetUsers",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Offers_OfferId",
                table: "AspNetUsers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id");
        }
    }
}
