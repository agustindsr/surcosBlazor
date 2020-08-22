using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class ListaPrecios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listaPrecios_estadoListaPrecios_EstadoListaPreciosId",
                table: "listaPrecios");

            migrationBuilder.DropIndex(
                name: "IX_listaPrecios_EstadoListaPreciosId",
                table: "listaPrecios");

            migrationBuilder.DropColumn(
                name: "EstadoListaPreciosId",
                table: "listaPrecios");

            migrationBuilder.DropColumn(
                name: "EstadpListaPreciosId",
                table: "listaPrecios");

            migrationBuilder.AddColumn<int>(
                name: "TipoListaPrecioId",
                table: "listaPrecios",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_listaPrecios_TipoListaPrecioId",
                table: "listaPrecios",
                column: "TipoListaPrecioId");

            migrationBuilder.AddForeignKey(
                name: "FK_listaPrecios_tipoListaPrecio_TipoListaPrecioId",
                table: "listaPrecios",
                column: "TipoListaPrecioId",
                principalTable: "tipoListaPrecio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listaPrecios_tipoListaPrecio_TipoListaPrecioId",
                table: "listaPrecios");

            migrationBuilder.DropIndex(
                name: "IX_listaPrecios_TipoListaPrecioId",
                table: "listaPrecios");

            migrationBuilder.DropColumn(
                name: "TipoListaPrecioId",
                table: "listaPrecios");

            migrationBuilder.AddColumn<int>(
                name: "EstadoListaPreciosId",
                table: "listaPrecios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstadpListaPreciosId",
                table: "listaPrecios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_listaPrecios_EstadoListaPreciosId",
                table: "listaPrecios",
                column: "EstadoListaPreciosId");

            migrationBuilder.AddForeignKey(
                name: "FK_listaPrecios_estadoListaPrecios_EstadoListaPreciosId",
                table: "listaPrecios",
                column: "EstadoListaPreciosId",
                principalTable: "estadoListaPrecios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
