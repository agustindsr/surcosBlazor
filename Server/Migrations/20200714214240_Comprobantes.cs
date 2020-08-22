using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class Comprobantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetalleFacturaId",
                table: "movimientoInventario",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "caja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoComprobante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoComprobante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    razonSocial = table.Column<string>(nullable: true),
                    nombreComercial = table.Column<string>(nullable: true),
                    celular = table.Column<string>(nullable: true),
                    DomicilioId = table.Column<int>(nullable: false),
                    fechaAlta = table.Column<DateTime>(nullable: false),
                    enabled = table.Column<bool>(nullable: false),
                    cuit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proveedor_domicilio_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "domicilio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tipoComprobante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoComprobante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "comprobante",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total = table.Column<decimal>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    enabled = table.Column<bool>(nullable: false),
                    totalCancelado = table.Column<decimal>(nullable: false),
                    totalComprobante = table.Column<decimal>(nullable: false),
                    totalImputado = table.Column<decimal>(nullable: false),
                    TipoComprobanteId = table.Column<int>(nullable: false),
                    DepositoId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true),
                    ProveedorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comprobante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comprobante_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comprobante_deposito_DepositoId",
                        column: x => x.DepositoId,
                        principalTable: "deposito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comprobante_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comprobante_tipoComprobante_TipoComprobanteId",
                        column: x => x.TipoComprobanteId,
                        principalTable: "tipoComprobante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalleFactura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(nullable: false),
                    subtotal = table.Column<double>(nullable: false),
                    bonificacion = table.Column<double>(nullable: false),
                    fechaAlta = table.Column<DateTime>(nullable: false),
                    enabled = table.Column<bool>(nullable: false),
                    ComprobanteId = table.Column<int>(nullable: false),
                    ProductoPresentacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleFactura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleFactura_comprobante_ComprobanteId",
                        column: x => x.ComprobanteId,
                        principalTable: "comprobante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleFactura_ProductoPresentacion_ProductoPresentacionId",
                        column: x => x.ProductoPresentacionId,
                        principalTable: "ProductoPresentacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detallePago",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComprobanteId = table.Column<int>(nullable: false),
                    subtotal = table.Column<decimal>(nullable: false),
                    CajaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallePago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detallePago_caja_CajaId",
                        column: x => x.CajaId,
                        principalTable: "caja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallePago_comprobante_ComprobanteId",
                        column: x => x.ComprobanteId,
                        principalTable: "comprobante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movimientoCaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    totalMovimiento = table.Column<decimal>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    entra = table.Column<bool>(nullable: false),
                    sale = table.Column<bool>(nullable: false),
                    descripcion = table.Column<string>(nullable: true),
                    CajaId = table.Column<int>(nullable: false),
                    DetalleFacturaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientoCaja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movimientoCaja_caja_CajaId",
                        column: x => x.CajaId,
                        principalTable: "caja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movimientoCaja_detalleFactura_DetalleFacturaId",
                        column: x => x.DetalleFacturaId,
                        principalTable: "detalleFactura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_DetalleFacturaId",
                table: "movimientoInventario",
                column: "DetalleFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_ClienteId",
                table: "comprobante",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_DepositoId",
                table: "comprobante",
                column: "DepositoId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_ProveedorId",
                table: "comprobante",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_TipoComprobanteId",
                table: "comprobante",
                column: "TipoComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleFactura_ComprobanteId",
                table: "detalleFactura",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleFactura_ProductoPresentacionId",
                table: "detalleFactura",
                column: "ProductoPresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_detallePago_CajaId",
                table: "detallePago",
                column: "CajaId");

            migrationBuilder.CreateIndex(
                name: "IX_detallePago_ComprobanteId",
                table: "detallePago",
                column: "ComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoCaja_CajaId",
                table: "movimientoCaja",
                column: "CajaId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoCaja_DetalleFacturaId",
                table: "movimientoCaja",
                column: "DetalleFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_DomicilioId",
                table: "Proveedor",
                column: "DomicilioId");

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_detalleFactura_DetalleFacturaId",
                table: "movimientoInventario",
                column: "DetalleFacturaId",
                principalTable: "detalleFactura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_detalleFactura_DetalleFacturaId",
                table: "movimientoInventario");

            migrationBuilder.DropTable(
                name: "detallePago");

            migrationBuilder.DropTable(
                name: "EstadoComprobante");

            migrationBuilder.DropTable(
                name: "movimientoCaja");

            migrationBuilder.DropTable(
                name: "caja");

            migrationBuilder.DropTable(
                name: "detalleFactura");

            migrationBuilder.DropTable(
                name: "comprobante");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "tipoComprobante");

            migrationBuilder.DropIndex(
                name: "IX_movimientoInventario_DetalleFacturaId",
                table: "movimientoInventario");

            migrationBuilder.DropColumn(
                name: "DetalleFacturaId",
                table: "movimientoInventario");
        }
    }
}
