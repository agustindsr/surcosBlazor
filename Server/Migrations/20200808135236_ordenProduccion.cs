using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class ordenProduccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estadoOrdenProduccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoOrdenProduccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ordenProduccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositoId = table.Column<int>(nullable: false),
                    EstadoOrdenProduccionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenProduccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordenProduccion_deposito_DepositoId",
                        column: x => x.DepositoId,
                        principalTable: "deposito",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ordenProduccion_estadoOrdenProduccion_EstadoOrdenProduccionId",
                        column: x => x.EstadoOrdenProduccionId,
                        principalTable: "estadoOrdenProduccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detallesOrdenProduccion",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<int>(nullable: false),
                    fechaAlta = table.Column<DateTime>(nullable: false),
                    OrdenProduccionId = table.Column<int>(nullable: false),
                    ProductoPresentacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detallesOrdenProduccion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_detallesOrdenProduccion_ordenProduccion_OrdenProduccionId",
                        column: x => x.OrdenProduccionId,
                        principalTable: "ordenProduccion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detallesOrdenProduccion_ProductoPresentacion_ProductoPresentacionId",
                        column: x => x.ProductoPresentacionId,
                        principalTable: "ProductoPresentacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detallesOrdenProduccion_OrdenProduccionId",
                table: "detallesOrdenProduccion",
                column: "OrdenProduccionId");

            migrationBuilder.CreateIndex(
                name: "IX_detallesOrdenProduccion_ProductoPresentacionId",
                table: "detallesOrdenProduccion",
                column: "ProductoPresentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_ordenProduccion_DepositoId",
                table: "ordenProduccion",
                column: "DepositoId");

            migrationBuilder.CreateIndex(
                name: "IX_ordenProduccion_EstadoOrdenProduccionId",
                table: "ordenProduccion",
                column: "EstadoOrdenProduccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detallesOrdenProduccion");

            migrationBuilder.DropTable(
                name: "ordenProduccion");

            migrationBuilder.DropTable(
                name: "estadoOrdenProduccion");
        }
    }
}
