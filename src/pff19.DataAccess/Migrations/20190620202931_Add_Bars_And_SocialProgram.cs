using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pff19.DataAccess.Migrations
{
    public partial class Add_Bars_And_SocialProgram : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameDe = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    DescriptionDe = table.Column<string>(nullable: true),
                    DescriptionFr = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    ImageThumbnail = table.Column<string>(nullable: true),
                    ImageLarge = table.Column<string>(nullable: true),
                    ImageMobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameDe = table.Column<string>(nullable: true),
                    NameFr = table.Column<string>(nullable: true),
                    DescriptionDe = table.Column<string>(nullable: true),
                    DescriptionFr = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    ImageThumbnail = table.Column<string>(nullable: true),
                    ImageLarge = table.Column<string>(nullable: true),
                    ImageMobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialPrograms", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "SocialPrograms");
        }
    }
}
