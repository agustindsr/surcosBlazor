using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class agregadoDeClases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleListaPrecios_productoPresentaciones_ProductoPresentacionId",
                table: "detalleListaPrecios");

            migrationBuilder.DropForeignKey(
                name: "FK_detallePedido_productoPresentaciones_ProductoPresentacionId",
                table: "detallePedido");

            migrationBuilder.DropForeignKey(
                name: "FK_productoPresentaciones_presentacionProducto_PresentacionProductoId",
                table: "productoPresentaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productoPresentaciones",
                table: "productoPresentaciones");

            migrationBuilder.RenameTable(
                name: "productoPresentaciones",
                newName: "ProductoPresentacion");

            migrationBuilder.RenameIndex(
                name: "IX_productoPresentaciones_PresentacionProductoId",
                table: "ProductoPresentacion",
                newName: "IX_ProductoPresentacion_PresentacionProductoId");

            migrationBuilder.AddColumn<int>(
                name: "ProductoId",
                table: "ProductoPresentacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductoPresentacion",
                table: "ProductoPresentacion",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "categoriaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaProducto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true),
                    enabled = table.Column<bool>(nullable: false),
                    CategoriaProductoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_producto_categoriaProducto_CategoriaProductoId",
                        column: x => x.CategoriaProductoId,
                        principalTable: "categoriaProducto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPresentacion_ProductoId",
                table: "ProductoPresentacion",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_producto_CategoriaProductoId",
                table: "producto",
                column: "CategoriaProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleListaPrecios_ProductoPresentacion_ProductoPresentacionId",
                table: "detalleListaPrecios",
                column: "ProductoPresentacionId",
                principalTable: "ProductoPresentacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detallePedido_ProductoPresentacion_ProductoPresentacionId",
                table: "detallePedido",
                column: "ProductoPresentacionId",
                principalTable: "ProductoPresentacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoPresentacion_presentacionProducto_PresentacionProductoId",
                table: "ProductoPresentacion",
                column: "PresentacionProductoId",
                principalTable: "presentacionProducto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoPresentacion_producto_ProductoId",
                table: "ProductoPresentacion",
                column: "ProductoId",
                principalTable: "producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalleListaPrecios_ProductoPresentacion_ProductoPresentacionId",
                table: "detalleListaPrecios");

            migrationBuilder.DropForeignKey(
                name: "FK_detallePedido_ProductoPresentacion_ProductoPresentacionId",
                table: "detallePedido");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoPresentacion_presentacionProducto_PresentacionProductoId",
                table: "ProductoPresentacion");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoPresentacion_producto_ProductoId",
                table: "ProductoPresentacion");

            migrationBuilder.DropTable(
                name: "producto");

            migrationBuilder.DropTable(
                name: "categoriaProducto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductoPresentacion",
                table: "ProductoPresentacion");

            migrationBuilder.DropIndex(
                name: "IX_ProductoPresentacion_ProductoId",
                table: "ProductoPresentacion");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "ProductoPresentacion");

            migrationBuilder.RenameTable(
                name: "ProductoPresentacion",
                newName: "productoPresentaciones");

            migrationBuilder.RenameIndex(
                name: "IX_ProductoPresentacion_PresentacionProductoId",
                table: "productoPresentaciones",
                newName: "IX_productoPresentaciones_PresentacionProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productoPresentaciones",
                table: "productoPresentaciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_detalleListaPrecios_productoPresentaciones_ProductoPresentacionId",
                table: "detalleListaPrecios",
                column: "ProductoPresentacionId",
                principalTable: "productoPresentaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detallePedido_productoPresentaciones_ProductoPresentacionId",
                table: "detallePedido",
                column: "ProductoPresentacionId",
                principalTable: "productoPresentaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productoPresentaciones_presentacionProducto_PresentacionProductoId",
                table: "productoPresentaciones",
                column: "PresentacionProductoId",
                principalTable: "presentacionProducto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
