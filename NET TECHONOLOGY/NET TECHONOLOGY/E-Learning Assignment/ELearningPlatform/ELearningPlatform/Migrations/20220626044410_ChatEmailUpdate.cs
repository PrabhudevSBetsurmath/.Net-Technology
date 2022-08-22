using Microsoft.EntityFrameworkCore.Migrations;

namespace ELearningPlatform.Migrations
{
    public partial class ChatEmailUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderName",
                table: "Chat",
                newName: "SenderEmail");

            migrationBuilder.RenameColumn(
                name: "ReceiverName",
                table: "Chat",
                newName: "ReceiverEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SenderEmail",
                table: "Chat",
                newName: "SenderName");

            migrationBuilder.RenameColumn(
                name: "ReceiverEmail",
                table: "Chat",
                newName: "ReceiverName");
        }
    }
}
