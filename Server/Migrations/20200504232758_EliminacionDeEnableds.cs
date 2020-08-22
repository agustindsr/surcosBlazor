using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class EliminacionDeEnableds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enabled",
                table: "vendedorDepartamento");

            migrationBuilder.DropColumn(
                name: "enabled",
                table: "provincias");

            migrationBuilder.DropColumn(
                name: "enabled",
                table: "departamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "vendedorDepartamento",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "provincias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "departamento",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
