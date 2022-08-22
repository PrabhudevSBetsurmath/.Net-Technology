using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearningPlatform.Migrations
{
    public partial class CalenderEventFacultyEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FacultyName",
                table: "CalenderEvents",
                newName: "FacultyEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FacultyEmail",
                table: "CalenderEvents",
                newName: "FacultyName");
        }
    }
}
