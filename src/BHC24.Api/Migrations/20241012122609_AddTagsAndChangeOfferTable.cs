using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHC24.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTagsAndChangeOfferTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Investors_InvestorId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_InvestorId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "InvestorId",
                table: "Offers");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Projects",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserTag",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTag", x => new { x.TagsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AppUserTag_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfferTag",
                columns: table => new
                {
                    OffersId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferTag", x => new { x.OffersId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_OfferTag_Offers_OffersId",
                        column: x => x.OffersId,
                        principalTable: "Offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_TagId",
                table: "Projects",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OfferId",
                table: "AspNetUsers",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTag_UsersId",
                table: "AppUserTag",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferTag_TagsId",
                table: "OfferTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Offers_OfferId",
                table: "AspNetUsers",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Tags_TagId",
                table: "Projects",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Offers_OfferId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Tags_TagId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "AppUserTag");

            migrationBuilder.DropTable(
                name: "OfferTag");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Projects_TagId",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OfferId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "InvestorId",
                table: "Offers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_InvestorId",
                table: "Offers",
                column: "InvestorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Investors_InvestorId",
                table: "Offers",
                column: "InvestorId",
                principalTable: "Investors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
