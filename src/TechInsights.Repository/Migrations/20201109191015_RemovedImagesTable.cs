using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInsights.Repository.Migrations
{
    public partial class RemovedImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PortfolioClient_Images_ClientImageId",
                table: "PortfolioClient");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_PortfolioClient_ClientImageId",
                table: "PortfolioClient");

            migrationBuilder.DropColumn(
                name: "ClientImageId",
                table: "PortfolioClient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientImageId",
                table: "PortfolioClient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioClient_ClientImageId",
                table: "PortfolioClient",
                column: "ClientImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PortfolioClient_Images_ClientImageId",
                table: "PortfolioClient",
                column: "ClientImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
