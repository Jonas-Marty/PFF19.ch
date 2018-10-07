using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pff19.DataAccess.Migrations
{
    public partial class FranceAndAddAssistants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "News",
                newName: "TitleFr");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "News",
                newName: "TitleDe");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Bands",
                newName: "DescriptionFr");

            migrationBuilder.AddColumn<string>(
                name: "ContentDe",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentFr",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionDe",
                table: "Bands",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Assistants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Vorname = table.Column<string>(nullable: true),
                    Pfadiname = table.Column<string>(nullable: true),
                    Wishes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistants", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assistants");

            migrationBuilder.DropColumn(
                name: "ContentDe",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ContentFr",
                table: "News");

            migrationBuilder.DropColumn(
                name: "DescriptionDe",
                table: "Bands");

            migrationBuilder.RenameColumn(
                name: "TitleFr",
                table: "News",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TitleDe",
                table: "News",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "DescriptionFr",
                table: "Bands",
                newName: "Description");
        }
    }
}
