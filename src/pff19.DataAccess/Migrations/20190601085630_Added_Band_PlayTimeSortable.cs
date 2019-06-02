using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pff19.DataAccess.Migrations
{
    public partial class Added_Band_PlayTimeSortable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PlayTimeForSorting",
                table: "Bands",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayTimeForSorting",
                table: "Bands");
        }
    }
}
