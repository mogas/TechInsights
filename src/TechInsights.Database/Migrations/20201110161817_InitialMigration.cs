using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace TechInsights.Database.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Subject = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForm", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortfolioClient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Client = table.Column<string>(nullable: false),
                    ProjectYear = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    ProjectUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Testimonial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Testimony = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonial", x => x.Id);
                });

            migrationBuilder.InsertData(
              table: "Testimonial",
              columns: new[] { "Name", "Position", "Testimony", "CreatedDate" },
              values: new object[] { "Dean Lynn", "Lead Technical Developer", "I worked closely with Nuno on one of Reading Room's biggest accounts; his attention to detail and enthusiasm allowed us to efficiently deliver ongoing improvements and major new functionality for our client's business critical, enterprise solution. Nuno learn's fast and would not shy away from challenging established project process and development practice. His feedback was invaluable; I could rely on Nuno to question solutions, raise and clearly communicate areas for improvement and propose alternative solutions based on his own knowledge and ongoing technical investigation. A great developer who applies his understanding of functional and non-functional requirements to produce high quality software.", DateTime.UtcNow });

            migrationBuilder.InsertData(
             table: "Testimonial",
             columns: new[] { "Name", "Position", "Testimony", "CreatedDate" },
             values: new object[] { "Sam Skivington", "Lead Developer", "Nuno is a self-motivated computer programmer who always thinks before he types. He's analytical and questions things that need to be questioned. Always asks questions when it's appropriate. If it was my company, I'd hire him.", DateTime.UtcNow });

            migrationBuilder.InsertData(
             table: "Testimonial",
             columns: new[] { "Name", "Position", "Testimony", "CreatedDate" },
             values: new object[] { "Michael Pajak", "Project Director", "I can offer a strong endorsement of Nuno as a work colleague and his capabilities as a .Net developer – particularly with Sitecore. He worked closely with me as a lead developer across a diverse portfolio of clients, supporting the technical delivery of Sitecore enablement strategies as well as more day-to-day issue resolution. Most importantly, he was able to offer invaluable client facing support when needed, really helping to find creative solutions to sometimes complex challenges.", DateTime.UtcNow });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactForm");

            migrationBuilder.DropTable(
                name: "PortfolioClient");

            migrationBuilder.DropTable(
                name: "Testimonial");
        }
    }
}
