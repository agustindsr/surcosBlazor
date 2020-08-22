using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class CreacionClaseFactura2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "subtotal",
                table: "detalleFactura");

            migrationBuilder.AddColumn<decimal>(
                name: "precioUnitario",
                table: "detalleFactura",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DomicilioId",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadoFacturaId",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListaPreciosId",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendedorId",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "celularCliente",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emailCliente",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEntrega",
                table: "comprobante",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombreCliente",
                table: "comprobante",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "estadoFactura",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoFactura", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_DomicilioId",
                table: "comprobante",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_EstadoFacturaId",
                table: "comprobante",
                column: "EstadoFacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_ListaPreciosId",
                table: "comprobante",
                column: "ListaPreciosId");

            migrationBuilder.CreateIndex(
                name: "IX_comprobante_VendedorId",
                table: "comprobante",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_domicilio_DomicilioId",
                table: "comprobante",
                column: "DomicilioId",
                principalTable: "domicilio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_estadoFactura_EstadoFacturaId",
                table: "comprobante",
                column: "EstadoFacturaId",
                principalTable: "estadoFactura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_listaPrecios_ListaPreciosId",
                table: "comprobante",
                column: "ListaPreciosId",
                principalTable: "listaPrecios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_vendedor_VendedorId",
                table: "comprobante",
                column: "VendedorId",
                principalTable: "vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_domicilio_DomicilioId",
                table: "comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_estadoFactura_EstadoFacturaId",
                table: "comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_listaPrecios_ListaPreciosId",
                table: "comprobante");

            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_vendedor_VendedorId",
                table: "comprobante");

            migrationBuilder.DropTable(
                name: "estadoFactura");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_DomicilioId",
                table: "comprobante");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_EstadoFacturaId",
                table: "comprobante");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_ListaPreciosId",
                table: "comprobante");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_VendedorId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "precioUnitario",
                table: "detalleFactura");

            migrationBuilder.DropColumn(
                name: "DomicilioId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "EstadoFacturaId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "ListaPreciosId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "VendedorId",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "celularCliente",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "emailCliente",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "fechaEntrega",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "nombreCliente",
                table: "comprobante");

            migrationBuilder.AddColumn<double>(
                name: "subtotal",
                table: "detalleFactura",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
