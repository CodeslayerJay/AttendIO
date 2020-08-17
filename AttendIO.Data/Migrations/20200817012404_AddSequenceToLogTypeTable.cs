using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendIO.Data.Migrations
{
    public partial class AddSequenceToLogTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sequence",
                table: "LogTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sequence",
                table: "LogTypes");
        }
    }
}
