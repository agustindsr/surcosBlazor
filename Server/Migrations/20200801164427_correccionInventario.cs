using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class correccionInventario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_detalleFacturaCompras_DetalleFacturaComprasId",
                table: "movimientoInventario");

            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_detalleFactura_DetalleFacturaId",
                table: "movimientoInventario");

            migrationBuilder.DropIndex(
                name: "IX_movimientoInventario_DetalleFacturaComprasId",
                table: "movimientoInventario");

            migrationBuilder.DropIndex(
                name: "IX_movimientoInventario_DetalleFacturaId",
                table: "movimientoInventario");

            migrationBuilder.DropColumn(
                name: "DetalleFacturaComprasId",
                table: "movimientoInventario");

            migrationBuilder.DropColumn(
                name: "DetalleFacturaId",
                table: "movimientoInventario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetalleFacturaComprasId",
                table: "movimientoInventario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetalleFacturaId",
                table: "movimientoInventario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_DetalleFacturaComprasId",
                table: "movimientoInventario",
                column: "DetalleFacturaComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_DetalleFacturaId",
                table: "movimientoInventario",
                column: "DetalleFacturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_detalleFacturaCompras_DetalleFacturaComprasId",
                table: "movimientoInventario",
                column: "DetalleFacturaComprasId",
                principalTable: "detalleFacturaCompras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_detalleFactura_DetalleFacturaId",
                table: "movimientoInventario",
                column: "DetalleFacturaId",
                principalTable: "detalleFactura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
