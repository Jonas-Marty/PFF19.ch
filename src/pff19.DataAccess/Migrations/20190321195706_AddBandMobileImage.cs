using Microsoft.EntityFrameworkCore.Migrations;

namespace pff19.DataAccess.Migrations
{
    public partial class AddBandMobileImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageMobile",
                table: "Bands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageMobile",
                table: "Bands");
        }
    }
}
