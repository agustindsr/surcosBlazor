using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class BorrarEntrega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_entrega_EntregaId",
                table: "pedido");

            migrationBuilder.DropTable(
                name: "entrega");

            migrationBuilder.DropIndex(
                name: "IX_pedido_EntregaId",
                table: "pedido");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DomicilioId",
                table: "pedido",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEntrega",
                table: "pedido",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "observaciones",
                table: "pedido",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_pedido_ClienteId",
                table: "pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_DomicilioId",
                table: "pedido",
                column: "DomicilioId");

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_cliente_ClienteId",
                table: "pedido",
                column: "ClienteId",
                principalTable: "cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_domicilio_DomicilioId",
                table: "pedido",
                column: "DomicilioId",
                principalTable: "domicilio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pedido_cliente_ClienteId",
                table: "pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_pedido_domicilio_DomicilioId",
                table: "pedido");

            migrationBuilder.DropIndex(
                name: "IX_pedido_ClienteId",
                table: "pedido");

            migrationBuilder.DropIndex(
                name: "IX_pedido_DomicilioId",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "DomicilioId",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "fechaEntrega",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "observaciones",
                table: "pedido");

            migrationBuilder.CreateTable(
                name: "entrega",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomicilioId = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrega", x => x.Id);
                    table.ForeignKey(
                        name: "FK_entrega_domicilio_DomicilioId",
                        column: x => x.DomicilioId,
                        principalTable: "domicilio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pedido_EntregaId",
                table: "pedido",
                column: "EntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_entrega_DomicilioId",
                table: "entrega",
                column: "DomicilioId");

            migrationBuilder.AddForeignKey(
                name: "FK_pedido_entrega_EntregaId",
                table: "pedido",
                column: "EntregaId",
                principalTable: "entrega",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
