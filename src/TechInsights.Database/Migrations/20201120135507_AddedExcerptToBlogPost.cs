using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInsights.Database.Migrations
{
    public partial class AddedExcerptToBlogPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Excerpt",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excerpt",
                table: "BlogPost");
        }
    }
}
