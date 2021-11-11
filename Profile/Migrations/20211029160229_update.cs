using Microsoft.EntityFrameworkCore.Migrations;

namespace ProfileManager.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentID",
                table: "Documents",
                newName: "DocumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentId",
                table: "Documents",
                newName: "DocumentID");
        }
    }
}
