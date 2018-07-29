using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Migrations;
using pff19.DataAccess.Utils;

namespace pff19.DataAccess.Migrations
{
    public partial class DefaultData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var salt = PasswordHelper.GenerateUserSalt();

            var passwordHash = PasswordHelper.GeneratePasswordHash("5LsfZ4vzL6J8hR5BuGGH", salt);

            var adminuser = new Dictionary<string, object>
            {
                ["FirstName"] = "Administrator",
                ["IsAdmin"] = true,
                ["Mail"] = "info@pff.ch",
                ["Name"] = "Administrator",
                ["PasswordHash"] = passwordHash,
                ["Ressort"] = "Kommunikation",
                ["Salt"] = salt,
                ["ScoutName"] = "admin",

            };
            migrationBuilder.InsertData("Users", adminuser.Keys.ToArray(), adminuser.Values.ToArray());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Users", "Mail", "info@pff.ch");
        }
    }
}
