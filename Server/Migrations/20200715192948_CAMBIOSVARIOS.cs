using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class CAMBIOSVARIOS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_deposito_DepositoId",
                table: "comprobante");

            migrationBuilder.AlterColumn<decimal>(
                name: "saldoCC",
                table: "cliente",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_deposito_DepositoId",
                table: "comprobante",
                column: "DepositoId",
                principalTable: "deposito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_deposito_DepositoId",
                table: "comprobante");

            migrationBuilder.AlterColumn<double>(
                name: "saldoCC",
                table: "cliente",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_deposito_DepositoId",
                table: "comprobante",
                column: "DepositoId",
                principalTable: "deposito",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
