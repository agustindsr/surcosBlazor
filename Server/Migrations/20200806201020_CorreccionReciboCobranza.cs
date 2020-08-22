using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class CorreccionReciboCobranza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoCaja_comprobante_ComprobanteAsociadoId",
                table: "movimientoCaja");

            migrationBuilder.DropIndex(
                name: "IX_movimientoCaja_ComprobanteAsociadoId",
                table: "movimientoCaja");

            migrationBuilder.DropColumn(
                name: "ComprobanteAsociacioId",
                table: "movimientoCaja");

            migrationBuilder.DropColumn(
                name: "ComprobanteAsociadoId",
                table: "movimientoCaja");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComprobanteAsociacioId",
                table: "movimientoCaja",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComprobanteAsociadoId",
                table: "movimientoCaja",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimientoCaja_ComprobanteAsociadoId",
                table: "movimientoCaja",
                column: "ComprobanteAsociadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoCaja_comprobante_ComprobanteAsociadoId",
                table: "movimientoCaja",
                column: "ComprobanteAsociadoId",
                principalTable: "comprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
