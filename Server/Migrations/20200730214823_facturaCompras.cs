using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class facturaCompras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_Proveedor_ProveedorId",
                table: "comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_vendedor_VendedorId",
                table: "comprobante");

            migrationBuilder.AddColumn<int>(
                name: "FacturaCompras_DepositoId",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacturaCompras_EstadoFacturaId",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacturaCompras_ListaPreciosId",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacturaCompras_TipoComprobanteId",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacturaCompras_codigo",
                table: "comprobante",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "detalleFacturaCompras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(nullable: false),
                    precioUnitario = table.Column<decimal>(nullable: false),
                    bonificacion = table.Column<double>(nullable: false),
                    fechaAlta = table.Column<DateTime>(nullable: false),
                    enabled = table.Column<bool>(nullable: false),
                    FacturaComprasId = table.Column<int>(nullable: false),
                    ProductoPresentacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalleFacturaCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detalleFacturaCompras_comprobante_FacturaComprasId",
                        column: x => x.FacturaComprasId,
                        principalTable: "comprobante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalleFacturaCompras_ProductoPresentacion_ProductoPresentacionId",
                        column: x => x.ProductoPresentacionId,
                        principalTable: "ProductoPresentacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_FacturaCompras_DepositoId",
                table: "comprobante",
                column: "FacturaCompras_DepositoId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_FacturaCompras_EstadoFacturaId",
                table: "comprobante",
                column: "FacturaCompras_EstadoFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_FacturaCompras_ListaPreciosId",
                table: "comprobante",
                column: "FacturaCompras_ListaPreciosId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_FacturaCompras_TipoComprobanteId",
                table: "comprobante",
                column: "FacturaCompras_TipoComprobanteId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleFacturaCompras_FacturaComprasId",
                table: "detalleFacturaCompras",
                column: "FacturaComprasId");

            migrationBuilder.CreateIndex(
                name: "IX_detalleFacturaCompras_ProductoPresentacionId",
                table: "detalleFacturaCompras",
                column: "ProductoPresentacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_vendedor_VendedorId",
                table: "comprobante",
                column: "VendedorId",
                principalTable: "vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_deposito_FacturaCompras_DepositoId",
                table: "comprobante",
                column: "FacturaCompras_DepositoId",
                principalTable: "deposito",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_estadoFactura_FacturaCompras_EstadoFacturaId",
                table: "comprobante",
                column: "FacturaCompras_EstadoFacturaId",
                principalTable: "estadoFactura",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_listaPrecios_FacturaCompras_ListaPreciosId",
                table: "comprobante",
                column: "FacturaCompras_ListaPreciosId",
                principalTable: "listaPrecios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_Proveedor_ProveedorId",
                table: "comprobante",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_tipoComprobante_FacturaCompras_TipoComprobanteId",
                table: "comprobante",
                column: "FacturaCompras_TipoComprobanteId",
                principalTable: "tipoComprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_vendedor_VendedorId",
                table: "comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_deposito_FacturaCompras_DepositoId",
                table: "comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_estadoFactura_FacturaCompras_EstadoFacturaId",
                table: "comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_listaPrecios_FacturaCompras_ListaPreciosId",
                table: "comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_Proveedor_ProveedorId",
                table: "comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_tipoComprobante_FacturaCompras_TipoComprobanteId",
                table: "comprobante");

            migrationBuilder.DropTable(
                name: "detalleFacturaCompras");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_FacturaCompras_DepositoId",
                table: "comprobante");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_FacturaCompras_EstadoFacturaId",
                table: "comprobante");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_FacturaCompras_ListaPreciosId",
                table: "comprobante");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_FacturaCompras_TipoComprobanteId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "FacturaCompras_DepositoId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "FacturaCompras_EstadoFacturaId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "FacturaCompras_ListaPreciosId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "FacturaCompras_TipoComprobanteId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "FacturaCompras_codigo",
                table: "comprobante");

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_Proveedor_ProveedorId",
                table: "comprobante",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_vendedor_VendedorId",
                table: "comprobante",
                column: "VendedorId",
                principalTable: "vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
