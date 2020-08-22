using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class Clasificaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clasificacion",
                table: "vendedor",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "clasificacion",
                table: "listaPrecios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "clasificacion",
                table: "detalleListaPrecios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "clasificacion",
                table: "categoriaProducto",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "clasificacion",
                table: "vendedor");

            migrationBuilder.DropColumn(
                name: "clasificacion",
                table: "listaPrecios");

            migrationBuilder.DropColumn(
                name: "clasificacion",
                table: "detalleListaPrecios");

            migrationBuilder.DropColumn(
                name: "clasificacion",
                table: "categoriaProducto");
        }
    }
}
