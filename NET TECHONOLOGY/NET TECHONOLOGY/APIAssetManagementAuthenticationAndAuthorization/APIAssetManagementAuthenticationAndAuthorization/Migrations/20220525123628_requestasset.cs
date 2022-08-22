using Microsoft.EntityFrameworkCore.Migrations;

namespace APIAssetManagementAuthenticationAndAuthorization.Migrations
{
    public partial class requestasset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestAsset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    AssetName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestAsset", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestAsset");
        }
    }
}
