using Microsoft.EntityFrameworkCore.Migrations;

namespace MouraSolutionsWeb.Migrations
{
    public partial class updateTotalCorrigido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "SystemUser");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "SystemUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "SystemUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SystemUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "SystemUser",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SystemUser");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "SystemUser");

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "SystemUser",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
