using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInsights.Repository.Migrations
{
    public partial class AddedTitleDescriptionToPortfolio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PortfolioClient",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "PortfolioClient",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PortfolioClient");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "PortfolioClient");
        }
    }
}
