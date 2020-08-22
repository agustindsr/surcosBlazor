using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class gananciaCostoPedidosComprobantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "costoTotal",
                table: "pedido",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "costo",
                table: "detallePedido",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "costo",
                table: "detalleFactura",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "costoTotal",
                table: "comprobante",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "costoTotal",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "costo",
                table: "detallePedido");

            migrationBuilder.DropColumn(
                name: "costo",
                table: "detalleFactura");

            migrationBuilder.DropColumn(
                name: "costoTotal",
                table: "comprobante");
        }
    }
}
