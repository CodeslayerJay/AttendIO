using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendIO.Data.Migrations
{
    public partial class UpdateUserTableWithUserSecurity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserSecurity_UserId",
                table: "UserSecurity");

            migrationBuilder.CreateIndex(
                name: "IX_UserSecurity_UserId",
                table: "UserSecurity",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserSecurity_UserId",
                table: "UserSecurity");

            migrationBuilder.CreateIndex(
                name: "IX_UserSecurity_UserId",
                table: "UserSecurity",
                column: "UserId");
        }
    }
}
