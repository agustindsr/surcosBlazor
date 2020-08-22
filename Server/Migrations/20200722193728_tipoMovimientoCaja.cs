using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class tipoMovimientoCaja : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoCaja_detalleFactura_DetalleFacturaId",
                table: "movimientoCaja");

            migrationBuilder.DropIndex(
                name: "IX_movimientoCaja_DetalleFacturaId",
                table: "movimientoCaja");

            migrationBuilder.DropColumn(
                name: "DetalleFacturaId",
                table: "movimientoCaja");

            migrationBuilder.AddColumn<int>(
                name: "TipoMovimientoCajaId",
                table: "movimientoCaja",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tipoMovimientoCaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoMovimientoCaja", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movimientoCaja_TipoMovimientoCajaId",
                table: "movimientoCaja",
                column: "TipoMovimientoCajaId");

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoCaja_tipoMovimientoCaja_TipoMovimientoCajaId",
                table: "movimientoCaja",
                column: "TipoMovimientoCajaId",
                principalTable: "tipoMovimientoCaja",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movimientoCaja_tipoMovimientoCaja_TipoMovimientoCajaId",
                table: "movimientoCaja");

            migrationBuilder.DropTable(
                name: "tipoMovimientoCaja");

            migrationBuilder.DropIndex(
                name: "IX_movimientoCaja_TipoMovimientoCajaId",
                table: "movimientoCaja");

            migrationBuilder.DropColumn(
                name: "TipoMovimientoCajaId",
                table: "movimientoCaja");

            migrationBuilder.AddColumn<int>(
                name: "DetalleFacturaId",
                table: "movimientoCaja",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_movimientoCaja_DetalleFacturaId",
                table: "movimientoCaja",
                column: "DetalleFacturaId");

            migrationBuilder.AddForeignKey(
                name: "FK_movimientoCaja_detalleFactura_DetalleFacturaId",
                table: "movimientoCaja",
                column: "DetalleFacturaId",
                principalTable: "detalleFactura",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
