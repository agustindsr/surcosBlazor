using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class comprasInventarioMovimientoCorreccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetalleFacturaComprasCompraId",
                table: "movimientoInventario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetalleFacturaComprasCompraId",
                table: "movimientoInventario",
                type: "int",
                nullable: true);
        }
    }
}
