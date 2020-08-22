using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class detallesFormula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFormula_FormulaProducto_FormulaProductoId",
                table: "DetalleFormula");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleFormula_ProductoPresentacion_ProductoPresentacionId",
                table: "DetalleFormula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalleFormula",
                table: "DetalleFormula");

            migrationBuilder.RenameTable(
                name: "DetalleFormula",
                newName: "detalleFormula");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleFormula_ProductoPresentacionId",
                table: "detalleFormula",
                newName: "IX_detalleFormula_ProductoPresentacionId");

            migrationBuilder.RenameIndex(
                name: "IX_DetalleFormula_FormulaProductoId",
                table: "detalleFormula",
                newName: "IX_detalleFormula_FormulaProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleFormula",
                table: "detalleFormula",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleFormula_FormulaProducto_FormulaProductoId",
                table: "detalleFormula",
                column: "FormulaProductoId",
                principalTable: "FormulaProducto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleFormula_ProductoPresentacion_ProductoPresentacionId",
                table: "detalleFormula",
                column: "ProductoPresentacionId",
                principalTable: "ProductoPresentacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleFormula_FormulaProducto_FormulaProductoId",
                table: "detalleFormula");

            migrationBuilder.DropForeignKey(
                name: "FK_detalleFormula_ProductoPresentacion_ProductoPresentacionId",
                table: "detalleFormula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalleFormula",
                table: "detalleFormula");

            migrationBuilder.RenameTable(
                name: "detalleFormula",
                newName: "DetalleFormula");

            migrationBuilder.RenameIndex(
                name: "IX_detalleFormula_ProductoPresentacionId",
                table: "DetalleFormula",
                newName: "IX_DetalleFormula_ProductoPresentacionId");

            migrationBuilder.RenameIndex(
                name: "IX_detalleFormula_FormulaProductoId",
                table: "DetalleFormula",
                newName: "IX_DetalleFormula_FormulaProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalleFormula",
                table: "DetalleFormula",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFormula_FormulaProducto_FormulaProductoId",
                table: "DetalleFormula",
                column: "FormulaProductoId",
                principalTable: "FormulaProducto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleFormula_ProductoPresentacion_ProductoPresentacionId",
                table: "DetalleFormula",
                column: "ProductoPresentacionId",
                principalTable: "ProductoPresentacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
