using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class IdDetalleListaPre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_detalleListaPrecios",
                table: "detalleListaPrecios");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "detalleListaPrecios",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleListaPrecios",
                table: "detalleListaPrecios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_detalleListaPrecios_ListaPreciosId",
                table: "detalleListaPrecios",
                column: "ListaPreciosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_detalleListaPrecios",
                table: "detalleListaPrecios");

            migrationBuilder.DropIndex(
                name: "IX_detalleListaPrecios_ListaPreciosId",
                table: "detalleListaPrecios");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "detalleListaPrecios");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalleListaPrecios",
                table: "detalleListaPrecios",
                columns: new[] { "ListaPreciosId", "ProductoPresentacionId" });
        }
    }
}
