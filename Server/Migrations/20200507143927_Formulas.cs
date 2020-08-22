using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class Formulas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormulaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    fechaCreacion = table.Column<DateTime>(nullable: false),
                    enabled = table.Column<bool>(nullable: false),
                    ProductoPresentacionId = table.Column<int>(nullable: false),
                    total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulaProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormulaProducto_ProductoPresentacion_ProductoPresentacionId",
                        column: x => x.ProductoPresentacionId,
                        principalTable: "ProductoPresentacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleFormula",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoPresentacionId = table.Column<int>(nullable: false),
                    cantidad = table.Column<double>(nullable: false),
                    FormulaProductoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleFormula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleFormula_FormulaProducto_FormulaProductoId",
                        column: x => x.FormulaProductoId,
                        principalTable: "FormulaProducto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleFormula_ProductoPresentacion_ProductoPresentacionId",
                        column: x => x.ProductoPresentacionId,
                        principalTable: "ProductoPresentacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFormula_FormulaProductoId",
                table: "DetalleFormula",
                column: "FormulaProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleFormula_ProductoPresentacionId",
                table: "DetalleFormula",
                column: "ProductoPresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulaProducto_ProductoPresentacionId",
                table: "FormulaProducto",
                column: "ProductoPresentacionId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleFormula");

            migrationBuilder.DropTable(
                name: "FormulaProducto");
        }
    }
}
