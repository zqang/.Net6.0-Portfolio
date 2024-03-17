using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioAPI.Migrations
{
    /// <inheritdoc />
    public partial class AuthorUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Authors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Authors_UserID",
                table: "Authors",
                column: "UserID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Users_UserID",
                table: "Authors",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Users_UserID",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_UserID",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Authors");
        }
    }
}
