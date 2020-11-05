using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInsights.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortfolioClient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    Client = table.Column<string>(nullable: false),
                    ProjectYear = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    ProjectUrl = table.Column<string>(nullable: true),
                    ClientImage = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioClient", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortfolioClient");
        }
    }
}
