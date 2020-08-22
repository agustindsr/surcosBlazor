using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class doubleToDecimalDetallePedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_clientes_ClienteId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_clientes_categoriaCliente_CategoriaClienteId",
                table: "clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_clientes_domicilio_DomicilioId",
                table: "clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "cliente");

            migrationBuilder.RenameIndex(
                name: "IX_clientes_DomicilioId",
                table: "cliente",
                newName: "IX_cliente_DomicilioId");

            migrationBuilder.RenameIndex(
                name: "IX_clientes_CategoriaClienteId",
                table: "cliente",
                newName: "IX_cliente_CategoriaClienteId");

            migrationBuilder.AlterColumn<decimal>(
                name: "precioUnitario",
                table: "detallePedido",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "descuento",
                table: "detallePedido",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cliente",
                table: "cliente",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_cliente_ClienteId",
                table: "AspNetUsers",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_cliente_categoriaCliente_CategoriaClienteId",
                table: "cliente",
                column: "CategoriaClienteId",
                principalTable: "categoriaCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_cliente_domicilio_DomicilioId",
                table: "cliente",
                column: "DomicilioId",
                principalTable: "domicilio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_cliente_ClienteId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_cliente_categoriaCliente_CategoriaClienteId",
                table: "cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_cliente_domicilio_DomicilioId",
                table: "cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cliente",
                table: "cliente");

            migrationBuilder.RenameTable(
                name: "cliente",
                newName: "clientes");

            migrationBuilder.RenameIndex(
                name: "IX_cliente_DomicilioId",
                table: "clientes",
                newName: "IX_clientes_DomicilioId");

            migrationBuilder.RenameIndex(
                name: "IX_cliente_CategoriaClienteId",
                table: "clientes",
                newName: "IX_clientes_CategoriaClienteId");

            migrationBuilder.AlterColumn<double>(
                name: "precioUnitario",
                table: "detallePedido",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<double>(
                name: "descuento",
                table: "detallePedido",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_clientes_ClienteId",
                table: "AspNetUsers",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_clientes_categoriaCliente_CategoriaClienteId",
                table: "clientes",
                column: "CategoriaClienteId",
                principalTable: "categoriaCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_clientes_domicilio_DomicilioId",
                table: "clientes",
                column: "DomicilioId",
                principalTable: "domicilio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
