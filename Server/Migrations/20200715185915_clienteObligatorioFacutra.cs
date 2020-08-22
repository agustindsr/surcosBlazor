using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class clienteObligatorioFacutra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_cliente_ClienteId",
                table: "comprobante");

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_cliente_ClienteId",
                table: "comprobante",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_cliente_ClienteId",
                table: "comprobante");

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_cliente_ClienteId",
                table: "comprobante",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
