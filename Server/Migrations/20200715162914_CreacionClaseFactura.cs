using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class CreacionClaseFactura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleFactura_comprobante_ComprobanteId",
                table: "detalleFactura");

            migrationBuilder.DropIndex(
                name: "IX_detalleFactura_ComprobanteId",
                table: "detalleFactura");

            migrationBuilder.DropColumn(
                name: "ComprobanteId",
                table: "detalleFactura");

            migrationBuilder.DropColumn(
                name: "total",
                table: "comprobante");

            migrationBuilder.AddColumn<int>(
                name: "FacturaId",
                table: "detalleFactura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "comprobante",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "codigo",
                table: "comprobante",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_detalleFactura_FacturaId",
                table: "detalleFactura",
                column: "FacturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleFactura_comprobante_FacturaId",
                table: "detalleFactura",
                column: "FacturaId",
                principalTable: "comprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleFactura_comprobante_FacturaId",
                table: "detalleFactura");

            migrationBuilder.DropIndex(
                name: "IX_detalleFactura_FacturaId",
                table: "detalleFactura");

            migrationBuilder.DropColumn(
                name: "FacturaId",
                table: "detalleFactura");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "comprobante");

            migrationBuilder.DropColumn(
                name: "codigo",
                table: "comprobante");

            migrationBuilder.AddColumn<int>(
                name: "ComprobanteId",
                table: "detalleFactura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "total",
                table: "comprobante",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_detalleFactura_ComprobanteId",
                table: "detalleFactura",
                column: "ComprobanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleFactura_comprobante_ComprobanteId",
                table: "detalleFactura",
                column: "ComprobanteId",
                principalTable: "comprobante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
