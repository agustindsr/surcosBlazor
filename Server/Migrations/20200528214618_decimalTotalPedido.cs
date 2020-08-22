using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class decimalTotalPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "total",
                table: "pedido",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_ClienteId",
                table: "pedido",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_cliente_ClienteId",
                table: "pedido",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_cliente_ClienteId",
                table: "pedido");

            migrationBuilder.DropIndex(
                name: "IX_pedido_ClienteId",
                table: "pedido");

            migrationBuilder.AlterColumn<double>(
                name: "total",
                table: "pedido",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
