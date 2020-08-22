using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class comprasInventarioMovimiento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_listaPrecios_FacturaCompras_ListaPreciosId",
                table: "comprobante");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_FacturaCompras_ListaPreciosId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "FacturaCompras_ListaPreciosId",
                table: "comprobante");

            migrationBuilder.AddColumn<int>(
                name: "DetalleFacturaComprasCompraId",
                table: "movimientoInventario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetalleFacturaComprasId",
                table: "movimientoInventario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_DetalleFacturaComprasId",
                table: "movimientoInventario",
                column: "DetalleFacturaComprasId");

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_detalleFacturaCompras_DetalleFacturaComprasId",
                table: "movimientoInventario",
                column: "DetalleFacturaComprasId",
                principalTable: "detalleFacturaCompras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_detalleFacturaCompras_DetalleFacturaComprasId",
                table: "movimientoInventario");

            migrationBuilder.DropIndex(
                name: "IX_movimientoInventario_DetalleFacturaComprasId",
                table: "movimientoInventario");

            migrationBuilder.DropColumn(
                name: "DetalleFacturaComprasCompraId",
                table: "movimientoInventario");

            migrationBuilder.DropColumn(
                name: "DetalleFacturaComprasId",
                table: "movimientoInventario");

            migrationBuilder.AddColumn<int>(
                name: "FacturaCompras_ListaPreciosId",
                table: "comprobante",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_FacturaCompras_ListaPreciosId",
                table: "comprobante",
                column: "FacturaCompras_ListaPreciosId");

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_listaPrecios_FacturaCompras_ListaPreciosId",
                table: "comprobante",
                column: "FacturaCompras_ListaPreciosId",
                principalTable: "listaPrecios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
