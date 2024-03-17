using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenameTagModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagName",
                table: "Tags",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TagDescription",
                table: "Tags",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tags",
                newName: "TagName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tags",
                newName: "TagDescription");
        }
    }
}
