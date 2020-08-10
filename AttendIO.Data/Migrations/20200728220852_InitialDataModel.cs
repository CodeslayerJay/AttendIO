using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AttendIO.Data.Migrations
{
    public partial class InitialDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CreatedAtLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TimeLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    LogTypeId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeLogs_LogTypes_LogTypeId",
                        column: x => x.LogTypeId,
                        principalTable: "LogTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TimeLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ModifiedLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeLogId = table.Column<int>(nullable: false),
                    ModifiedById = table.Column<int>(nullable: false),
                    PropertyChanged = table.Column<string>(nullable: false),
                    OriginalValue = table.Column<string>(nullable: true),
                    ChangedValue = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModifiedLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModifiedLogs_Users_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ModifiedLogs_TimeLogs_TimeLogId",
                        column: x => x.TimeLogId,
                        principalTable: "TimeLogs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedLogs_ModifiedById",
                table: "ModifiedLogs",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_ModifiedLogs_TimeLogId",
                table: "ModifiedLogs",
                column: "TimeLogId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLogs_LogTypeId",
                table: "TimeLogs",
                column: "LogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeLogs_UserId",
                table: "TimeLogs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationLogs");

            migrationBuilder.DropTable(
                name: "ModifiedLogs");

            migrationBuilder.DropTable(
                name: "TimeLogs");

            migrationBuilder.DropTable(
                name: "LogTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
