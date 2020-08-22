using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class arreglosEnDetalleListaPrecio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IVA",
                table: "detalleListaPrecios");

            migrationBuilder.DropColumn(
                name: "precioUnitarioNeto",
                table: "detalleListaPrecios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "IVA",
                table: "detalleListaPrecios",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "precioUnitarioNeto",
                table: "detalleListaPrecios",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
