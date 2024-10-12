using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHC24.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Offers_OfferId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "OfferId",
                table: "AspNetUsers",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_OfferId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_ProjectId");

            migrationBuilder.AddColumn<int>(
                name: "InvestorId",
                table: "Offers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Offers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_InvestorId",
                table: "Offers",
                column: "InvestorId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_ProjectId",
                table: "Offers",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectId",
                table: "AspNetUsers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Investors_InvestorId",
                table: "Offers",
                column: "InvestorId",
                principalTable: "Investors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Projects_ProjectId",
                table: "Offers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Projects_ProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Investors_InvestorId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Projects_ProjectId",
                table: "Offers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Offers_InvestorId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_ProjectId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "InvestorId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "AspNetUsers",
                newName: "OfferId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_ProjectId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Offers_OfferId",
                table: "AspNetUsers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id");
        }
    }
}
