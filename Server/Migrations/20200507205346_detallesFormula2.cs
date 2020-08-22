using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class detallesFormula2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleFormula_FormulaProducto_FormulaProductoId",
                table: "detalleFormula");

            migrationBuilder.AlterColumn<int>(
                name: "FormulaProductoId",
                table: "detalleFormula",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_detalleFormula_FormulaProducto_FormulaProductoId",
                table: "detalleFormula",
                column: "FormulaProductoId",
                principalTable: "FormulaProducto",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleFormula_FormulaProducto_FormulaProductoId",
                table: "detalleFormula");

            migrationBuilder.AlterColumn<int>(
                name: "FormulaProductoId",
                table: "detalleFormula",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_detalleFormula_FormulaProducto_FormulaProductoId",
                table: "detalleFormula",
                column: "FormulaProductoId",
                principalTable: "FormulaProducto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
