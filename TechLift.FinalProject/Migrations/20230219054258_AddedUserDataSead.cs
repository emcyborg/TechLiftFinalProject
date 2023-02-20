using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechLift.FinalProject.Migrations
{
    public partial class AddedUserDataSead : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Deleted", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "8035c690-70d8-4c9d-82c4-104bd0b2dcaf", false, "admin@gmail.com", true, "Awais", "Awan", false, null, "admin@gmail.com", "AWAIS", "AQAAAAEAACcQAAAAEMWYn+mZkkjtGIUVVPBiZW0oe8e60oJ0t+G5uMIwfbBIRlcTqpBPXSCvEwWmo1v0ug==", "03234234", true, "QPHY6ZG4LMBODR36AM3C4UHGDBRMYOX7", true, "Awais" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
