using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pff19.DataAccess.Migrations
{
    public partial class NewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "News",
                newName: "Images");

            migrationBuilder.AddColumn<string>(
                name: "LinkInstagram",
                table: "News",
                nullable: true);


            migrationBuilder.AddColumn<string>(
                name: "LinkFacebook",
                table: "News",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Sponsors",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "News",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "News");

            migrationBuilder.DropColumn(
                name: "LinkInstagram",
                table: "News");

            migrationBuilder.DropColumn(
                name: "LinkFacebook",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "News",
                newName: "Image");
        }
    }
}
