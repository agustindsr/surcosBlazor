using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class datosPedidoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_cliente_ClienteId",
                table: "pedido");

            migrationBuilder.DropIndex(
                name: "IX_pedido_ClienteId",
                table: "pedido");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "pedido",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "celularCliente",
                table: "pedido",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "emailCliente",
                table: "pedido",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombreCliente",
                table: "pedido",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "celularCliente",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "emailCliente",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "nombreCliente",
                table: "pedido");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "pedido",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
