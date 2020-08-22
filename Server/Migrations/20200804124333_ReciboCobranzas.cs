using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class ReciboCobranzas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReciboCobranzasId",
                table: "movimientoCaja",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReciboCobranzas_ClienteId",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoReciboId",
                table: "comprobante",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "estadoRecibo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoRecibo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "imputacionComprobantesVenta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaVentasId = table.Column<int>(nullable: false),
                    FacturaVentaId = table.Column<int>(nullable: true),
                    ComprobanteImputadoId = table.Column<int>(nullable: false),
                    totalImputado = table.Column<decimal>(nullable: false),
                    ReciboCobranzasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imputacionComprobantesVenta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imputacionComprobantesVenta_comprobante_ComprobanteImputadoId",
                        column: x => x.ComprobanteImputadoId,
                        principalTable: "comprobante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_imputacionComprobantesVenta_comprobante_FacturaVentaId",
                        column: x => x.FacturaVentaId,
                        principalTable: "comprobante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_imputacionComprobantesVenta_comprobante_ReciboCobranzasId",
                        column: x => x.ReciboCobranzasId,
                        principalTable: "comprobante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimientoCaja_ReciboCobranzasId",
                table: "movimientoCaja",
                column: "ReciboCobranzasId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_ReciboCobranzas_ClienteId",
                table: "comprobante",
                column: "ReciboCobranzas_ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_EstadoReciboId",
                table: "comprobante",
                column: "EstadoReciboId");

            migrationBuilder.CreateIndex(
                name: "IX_imputacionComprobantesVenta_ComprobanteImputadoId",
                table: "imputacionComprobantesVenta",
                column: "ComprobanteImputadoId");

            migrationBuilder.CreateIndex(
                name: "IX_imputacionComprobantesVenta_FacturaVentaId",
                table: "imputacionComprobantesVenta",
                column: "FacturaVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_imputacionComprobantesVenta_ReciboCobranzasId",
                table: "imputacionComprobantesVenta",
                column: "ReciboCobranzasId");

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_cliente_ReciboCobranzas_ClienteId",
                table: "comprobante",
                column: "ReciboCobranzas_ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_estadoRecibo_EstadoReciboId",
                table: "comprobante",
                column: "EstadoReciboId",
                principalTable: "estadoRecibo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoCaja_comprobante_ReciboCobranzasId",
                table: "movimientoCaja",
                column: "ReciboCobranzasId",
                principalTable: "comprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_cliente_ReciboCobranzas_ClienteId",
                table: "comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_estadoRecibo_EstadoReciboId",
                table: "comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_movimientoCaja_comprobante_ReciboCobranzasId",
                table: "movimientoCaja");

            migrationBuilder.DropTable(
                name: "estadoRecibo");

            migrationBuilder.DropTable(
                name: "imputacionComprobantesVenta");

            migrationBuilder.DropIndex(
                name: "IX_movimientoCaja_ReciboCobranzasId",
                table: "movimientoCaja");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_ReciboCobranzas_ClienteId",
                table: "comprobante");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_EstadoReciboId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "ReciboCobranzasId",
                table: "movimientoCaja");

            migrationBuilder.DropColumn(
                name: "ReciboCobranzas_ClienteId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "EstadoReciboId",
                table: "comprobante");
        }
    }
}
