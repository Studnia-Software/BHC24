using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BHC24.Api.Migrations
{
    /// <inheritdoc />
    public partial class SwitchFromUserToProfileOnProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_AspNetUsers_OwnerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Profiles_ProfileId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Profiles_ProfileId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "AppUserTag");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ProfileId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ProfileId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Projects");

            migrationBuilder.AddColumn<Guid>(
                name: "AppUserId",
                table: "Tags",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OwnerId",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "ProfileTag",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileTag", x => new { x.TagsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ProfileTag_Profiles_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_AppUserId",
                table: "Tags",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileTag_UsersId",
                table: "ProfileTag",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Profiles_OwnerId",
                table: "Projects",
                column: "OwnerId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_AspNetUsers_AppUserId",
                table: "Tags",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Profiles_OwnerId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_AspNetUsers_AppUserId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "ProfileTag");

            migrationBuilder.DropIndex(
                name: "IX_Tags_AppUserId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Tags",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OwnerId",
                table: "Projects",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Projects",
                type: "INTEGER",
                nullable: true);

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
                name: "IX_Tags_ProfileId",
                table: "Tags",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProfileId",
                table: "Projects",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_AppUserTag_UsersId",
                table: "AppUserTag",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_AspNetUsers_OwnerId",
                table: "Projects",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Profiles_ProfileId",
                table: "Projects",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Profiles_ProfileId",
                table: "Tags",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");
        }
    }
}
