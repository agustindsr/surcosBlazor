using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class CorreccionImputacionCobranza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imputacionComprobantesVenta_comprobante_ComprobanteImputadoId",
                table: "imputacionComprobantesVenta");

            migrationBuilder.DropForeignKey(
                name: "FK_imputacionComprobantesVenta_comprobante_ReciboCobranzasId",
                table: "imputacionComprobantesVenta");

            migrationBuilder.DropIndex(
                name: "IX_imputacionComprobantesVenta_ComprobanteImputadoId",
                table: "imputacionComprobantesVenta");

            migrationBuilder.DropColumn(
                name: "ComprobanteImputadoId",
                table: "imputacionComprobantesVenta");

            migrationBuilder.AlterColumn<int>(
                name: "ReciboCobranzasId",
                table: "imputacionComprobantesVenta",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_imputacionComprobantesVenta_comprobante_ReciboCobranzasId",
                table: "imputacionComprobantesVenta",
                column: "ReciboCobranzasId",
                principalTable: "comprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_imputacionComprobantesVenta_comprobante_ReciboCobranzasId",
                table: "imputacionComprobantesVenta");

            migrationBuilder.AlterColumn<int>(
                name: "ReciboCobranzasId",
                table: "imputacionComprobantesVenta",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ComprobanteImputadoId",
                table: "imputacionComprobantesVenta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_imputacionComprobantesVenta_ComprobanteImputadoId",
                table: "imputacionComprobantesVenta",
                column: "ComprobanteImputadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_imputacionComprobantesVenta_comprobante_ComprobanteImputadoId",
                table: "imputacionComprobantesVenta",
                column: "ComprobanteImputadoId",
                principalTable: "comprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_imputacionComprobantesVenta_comprobante_ReciboCobranzasId",
                table: "imputacionComprobantesVenta",
                column: "ReciboCobranzasId",
                principalTable: "comprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
