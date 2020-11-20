using Microsoft.EntityFrameworkCore.Migrations;

namespace TechInsights.Database.Migrations
{
    public partial class AddedBlogPostIdToComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComment_BlogPost_BlogPostId",
                table: "BlogPostComment");

            migrationBuilder.AlterColumn<int>(
                name: "BlogPostId",
                table: "BlogPostComment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComment_BlogPost_BlogPostId",
                table: "BlogPostComment",
                column: "BlogPostId",
                principalTable: "BlogPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComment_BlogPost_BlogPostId",
                table: "BlogPostComment");

            migrationBuilder.AlterColumn<int>(
                name: "BlogPostId",
                table: "BlogPostComment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComment_BlogPost_BlogPostId",
                table: "BlogPostComment",
                column: "BlogPostId",
                principalTable: "BlogPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
