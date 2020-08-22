using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class ProveedorOrdenDePago : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_comprobante_OrdenPago_ProveedorId",
                table: "comprobante",
                column: "OrdenPago_ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_comprobante_Proveedor_OrdenPago_ProveedorId",
                table: "comprobante",
                column: "OrdenPago_ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comprobante_Proveedor_OrdenPago_ProveedorId",
                table: "comprobante");

            migrationBuilder.DropIndex(
                name: "IX_comprobante_OrdenPago_ProveedorId",
                table: "comprobante");
        }
    }
}
