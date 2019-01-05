using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pff19.DataAccess.Migrations
{
    public partial class NewFieldsForBands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bands",
                nullable: true,
                oldClrType: typeof(string));

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
                name: "Facebook",
                table: "Bands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageLarge",
                table: "Bands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnail",
                table: "Bands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Instagram",
                table: "Bands",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Bands",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PlayTime",
                table: "Bands",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SpotifyPlaylist",
                table: "Bands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebSiteUrl",
                table: "Bands",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YoutubeUrls",
                table: "Bands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "ImageLarge",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "ImageThumbnail",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "Instagram",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "PlayTime",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "SpotifyPlaylist",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "WebSiteUrl",
                table: "Bands");

            migrationBuilder.DropColumn(
                name: "YoutubeUrls",
                table: "Bands");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bands",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
        }
    }
}
