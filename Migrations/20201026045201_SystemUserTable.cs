using Microsoft.EntityFrameworkCore.Migrations;

namespace MouraSolutionsWeb.Migrations
{
    public partial class SystemUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Material",
                table: "Material");

            migrationBuilder.RenameTable(
                name: "Material",
                newName: "SystemUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SystemUser",
                table: "SystemUser",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SystemUser",
                table: "SystemUser");

            migrationBuilder.RenameTable(
                name: "SystemUser",
                newName: "Material");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material",
                table: "Material",
                column: "Id");
        }
    }
}
