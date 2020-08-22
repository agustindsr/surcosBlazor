using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class EnabledPresentacionProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unidades",
                table: "presentacionProducto");

            migrationBuilder.AddColumn<double>(
                name: "cantidad",
                table: "presentacionProducto",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "presentacionProducto",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cantidad",
                table: "presentacionProducto");

            migrationBuilder.DropColumn(
                name: "enabled",
                table: "presentacionProducto");

            migrationBuilder.AddColumn<double>(
                name: "unidades",
                table: "presentacionProducto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
