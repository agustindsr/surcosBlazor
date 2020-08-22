using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class productoCategoriaOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_producto_categoriaProducto_CategoriaProductoId",
                table: "producto");

            migrationBuilder.DropColumn(
                name: "enabled",
                table: "categoriaProducto");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaProductoId",
                table: "producto",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_producto_categoriaProducto_CategoriaProductoId",
                table: "producto",
                column: "CategoriaProductoId",
                principalTable: "categoriaProducto",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_producto_categoriaProducto_CategoriaProductoId",
                table: "producto");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaProductoId",
                table: "producto",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "categoriaProducto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_producto_categoriaProducto_CategoriaProductoId",
                table: "producto",
                column: "CategoriaProductoId",
                principalTable: "categoriaProducto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
