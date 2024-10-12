using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHC24.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserTag");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Tags",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GithubAccountUrl = table.Column<string>(type: "TEXT", nullable: true),
                    LinkedInAccountUrl = table.Column<string>(type: "TEXT", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "BLOB", nullable: true),
                    UserCv = table.Column<byte[]>(type: "BLOB", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    AppUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ProfileId",
                table: "Tags",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TagId",
                table: "AspNetUsers",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_AppUserId",
                table: "Profiles",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tags_TagId",
                table: "AspNetUsers",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Profiles_ProfileId",
                table: "Tags",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tags_TagId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Profiles_ProfileId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ProfileId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TagId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "AspNetUsers");

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

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTag_UsersId",
                table: "AppUserTag",
                column: "UsersId");
        }
    }
}
