using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class MovimientoInventarioRelacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_inventario_InventarioId",
                table: "movimientoInventario");

            migrationBuilder.AlterColumn<int>(
                name: "InventarioId",
                table: "movimientoInventario",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_inventario_InventarioId",
                table: "movimientoInventario",
                column: "InventarioId",
                principalTable: "inventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_inventario_InventarioId",
                table: "movimientoInventario");

            migrationBuilder.AlterColumn<int>(
                name: "InventarioId",
                table: "movimientoInventario",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_inventario_InventarioId",
                table: "movimientoInventario",
                column: "InventarioId",
                principalTable: "inventario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
