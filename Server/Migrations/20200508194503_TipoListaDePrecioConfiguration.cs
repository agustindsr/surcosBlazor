using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class TipoListaDePrecioConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categoriaClienteTipoListaPrecio");

            migrationBuilder.CreateTable(
                name: "TipoListaPrecioCategoriaCliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoListaPrecioId = table.Column<int>(nullable: false),
                    CategoriaClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoListaPrecioCategoriaCliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoListaPrecioCategoriaCliente_categoriaCliente_CategoriaClienteId",
                        column: x => x.CategoriaClienteId,
                        principalTable: "categoriaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoListaPrecioCategoriaCliente_tipoListaPrecio_TipoListaPrecioId",
                        column: x => x.TipoListaPrecioId,
                        principalTable: "tipoListaPrecio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoListaPrecioProvincia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoListaPrecioId = table.Column<int>(nullable: false),
                    ProvinciaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoListaPrecioProvincia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TipoListaPrecioProvincia_provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TipoListaPrecioProvincia_tipoListaPrecio_TipoListaPrecioId",
                        column: x => x.TipoListaPrecioId,
                        principalTable: "tipoListaPrecio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TipoListaPrecioCategoriaCliente_CategoriaClienteId",
                table: "TipoListaPrecioCategoriaCliente",
                column: "CategoriaClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoListaPrecioCategoriaCliente_TipoListaPrecioId",
                table: "TipoListaPrecioCategoriaCliente",
                column: "TipoListaPrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoListaPrecioProvincia_ProvinciaId",
                table: "TipoListaPrecioProvincia",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_TipoListaPrecioProvincia_TipoListaPrecioId",
                table: "TipoListaPrecioProvincia",
                column: "TipoListaPrecioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoListaPrecioCategoriaCliente");

            migrationBuilder.DropTable(
                name: "TipoListaPrecioProvincia");

            migrationBuilder.CreateTable(
                name: "categoriaClienteTipoListaPrecio",
                columns: table => new
                {
                    CategoriaClienteId = table.Column<int>(type: "int", nullable: false),
                    TipoListaPrecioId = table.Column<int>(type: "int", nullable: false),
                    habilitada = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaClienteTipoListaPrecio", x => new { x.CategoriaClienteId, x.TipoListaPrecioId });
                    table.ForeignKey(
                        name: "FK_categoriaClienteTipoListaPrecio_categoriaCliente_CategoriaClienteId",
                        column: x => x.CategoriaClienteId,
                        principalTable: "categoriaCliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoriaClienteTipoListaPrecio_tipoListaPrecio_TipoListaPrecioId",
                        column: x => x.TipoListaPrecioId,
                        principalTable: "tipoListaPrecio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categoriaClienteTipoListaPrecio_TipoListaPrecioId",
                table: "categoriaClienteTipoListaPrecio",
                column: "TipoListaPrecioId");
        }
    }
}
