using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class quitarEnabledFormula2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleFormula_FormulaProducto_FormulaProductoId",
                table: "detalleFormula");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleFormula_ProductoPresentacion_ProductoPresentacionId",
                table: "detalleFormula");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleFormula_FormulaProducto_FormulaProductoId",
                table: "detalleFormula",
                column: "FormulaProductoId",
                principalTable: "FormulaProducto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleFormula_ProductoPresentacion_ProductoPresentacionId",
                table: "detalleFormula",
                column: "ProductoPresentacionId",
                principalTable: "ProductoPresentacion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleFormula_FormulaProducto_FormulaProductoId",
                table: "detalleFormula");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleFormula_ProductoPresentacion_ProductoPresentacionId",
                table: "detalleFormula");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleFormula_FormulaProducto_FormulaProductoId",
                table: "detalleFormula",
                column: "FormulaProductoId",
                principalTable: "FormulaProducto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleFormula_ProductoPresentacion_ProductoPresentacionId",
                table: "detalleFormula",
                column: "ProductoPresentacionId",
                principalTable: "ProductoPresentacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
