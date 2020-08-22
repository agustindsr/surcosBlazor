using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class detallePedidoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detallePedido_pedido_PedidoId",
                table: "detallePedido");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "detallePedido",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_detallePedido_pedido_PedidoId",
                table: "detallePedido",
                column: "PedidoId",
                principalTable: "pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detallePedido_pedido_PedidoId",
                table: "detallePedido");

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "detallePedido",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_detallePedido_pedido_PedidoId",
                table: "detallePedido",
                column: "PedidoId",
                principalTable: "pedido",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
