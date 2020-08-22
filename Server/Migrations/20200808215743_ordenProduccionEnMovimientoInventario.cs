using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class ordenProduccionEnMovimientoInventario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "fecha",
                table: "ordenProduccion",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OrdenProduccionId",
                table: "movimientoInventario",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimientoInventario_OrdenProduccionId",
                table: "movimientoInventario",
                column: "OrdenProduccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoInventario_ordenProduccion_OrdenProduccionId",
                table: "movimientoInventario",
                column: "OrdenProduccionId",
                principalTable: "ordenProduccion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoInventario_ordenProduccion_OrdenProduccionId",
                table: "movimientoInventario");

            migrationBuilder.DropIndex(
                name: "IX_movimientoInventario_OrdenProduccionId",
                table: "movimientoInventario");

            migrationBuilder.DropColumn(
                name: "fecha",
                table: "ordenProduccion");

            migrationBuilder.DropColumn(
                name: "OrdenProduccionId",
                table: "movimientoInventario");
        }
    }
}
