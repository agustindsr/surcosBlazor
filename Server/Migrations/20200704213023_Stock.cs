using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class Stock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deposito",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    DomicilioId = table.Column<int>(nullable: false),
                    enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deposito", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deposito_domicilio_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "domicilio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoPresentacionId = table.Column<int>(nullable: false),
                    cantidadUnidadesEnExistencia = table.Column<int>(nullable: false),
                    cantidadPesoRealEnExistencia = table.Column<decimal>(nullable: false),
                    DepositoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inventario_deposito_DepositoId",
                        column: x => x.DepositoId,
                        principalTable: "deposito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inventario_ProductoPresentacion_ProductoPresentacionId",
                        column: x => x.ProductoPresentacionId,
                        principalTable: "ProductoPresentacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movimientoInventario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidadUnidadesMovida = table.Column<int>(nullable: false),
                    fecha = table.Column<DateTime>(nullable: false),
                    entra = table.Column<bool>(nullable: false),
                    sale = table.Column<bool>(nullable: false),
                    InventarioId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientoInventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_movimientoInventario_inventario_InventarioId",
                        column: x => x.InventarioId,
                        principalTable: "inventario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_deposito_DomicilioId",
                table: "deposito",
                column: "DomicilioId");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_DepositoId",
                table: "inventario",
                column: "DepositoId");

            migrationBuilder.CreateIndex(
                name: "IX_inventario_ProductoPresentacionId",
                table: "inventario",
                column: "ProductoPresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_InventarioId",
                table: "movimientoInventario",
                column: "InventarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimientoInventario");

            migrationBuilder.DropTable(
                name: "inventario");

            migrationBuilder.DropTable(
                name: "deposito");
        }
    }
}
