using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class ordenDeCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdenPagoId",
                table: "movimientoCaja",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrdenPago_ProveedorId",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReciboCobranzas_EstadoReciboId",
                table: "comprobante",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "imputacionComprobantesCompra",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaComprasId = table.Column<int>(nullable: false),
                    OrdenPagoId = table.Column<int>(nullable: false),
                    totalImputado = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imputacionComprobantesCompra", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imputacionComprobantesCompra_comprobante_FacturaComprasId",
                        column: x => x.FacturaComprasId,
                        principalTable: "comprobante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_imputacionComprobantesCompra_comprobante_OrdenPagoId",
                        column: x => x.OrdenPagoId,
                        principalTable: "comprobante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimientoCaja_OrdenPagoId",
                table: "movimientoCaja",
                column: "OrdenPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_ReciboCobranzas_EstadoReciboId",
                table: "comprobante",
                column: "ReciboCobranzas_EstadoReciboId");

            migrationBuilder.CreateIndex(
                name: "IX_imputacionComprobantesCompra_FacturaComprasId",
                table: "imputacionComprobantesCompra",
                column: "FacturaComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_imputacionComprobantesCompra_OrdenPagoId",
                table: "imputacionComprobantesCompra",
                column: "OrdenPagoId");

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_estadoRecibo_ReciboCobranzas_EstadoReciboId",
                table: "comprobante",
                column: "ReciboCobranzas_EstadoReciboId",
                principalTable: "estadoRecibo",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoCaja_comprobante_OrdenPagoId",
                table: "movimientoCaja",
                column: "OrdenPagoId",
                principalTable: "comprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_estadoRecibo_ReciboCobranzas_EstadoReciboId",
                table: "comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_movimientoCaja_comprobante_OrdenPagoId",
                table: "movimientoCaja");

            migrationBuilder.DropTable(
                name: "imputacionComprobantesCompra");

            migrationBuilder.DropIndex(
                name: "IX_movimientoCaja_OrdenPagoId",
                table: "movimientoCaja");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_ReciboCobranzas_EstadoReciboId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "OrdenPagoId",
                table: "movimientoCaja");

            migrationBuilder.DropColumn(
                name: "OrdenPago_ProveedorId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "ReciboCobranzas_EstadoReciboId",
                table: "comprobante");
        }
    }
}
