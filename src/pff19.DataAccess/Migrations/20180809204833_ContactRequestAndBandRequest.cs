using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pff19.DataAccess.Migrations
{
    public partial class ContactRequestAndBandRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "ReferenceToScout",
                table: "Bands");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionFr",
                table: "Bands",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionDe",
                table: "Bands",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bands",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BandRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    ReferenceToScout = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Mail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactRequests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BandRequests");

            migrationBuilder.DropTable(
                name: "ContactRequests");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bands");

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionFr",
                table: "Bands",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DescriptionDe",
                table: "Bands",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Bands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Bands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReferenceToScout",
                table: "Bands",
                nullable: true);
        }
    }
}
