using Microsoft.EntityFrameworkCore.Migrations;

namespace pff19.DataAccess.Migrations
{
    public partial class NewsPreview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PreviewDe",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviewFr",
                table: "News",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviewDe",
                table: "News");

            migrationBuilder.DropColumn(
                name: "PreviewFr",
                table: "News");
        }
    }
}
