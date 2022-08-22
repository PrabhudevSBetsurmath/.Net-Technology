using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearningPlatform.Migrations
{
    public partial class CalenderEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalenderEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalenderEvents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalenderEvents");
        }
    }
}
