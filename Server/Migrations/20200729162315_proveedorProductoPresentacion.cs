using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class proveedorProductoPresentacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "ProductoPresentacion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductoPresentacion_ProveedorId",
                table: "ProductoPresentacion",
                column: "ProveedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoPresentacion_Proveedor_ProveedorId",
                table: "ProductoPresentacion",
                column: "ProveedorId",
                principalTable: "Proveedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoPresentacion_Proveedor_ProveedorId",
                table: "ProductoPresentacion");

            migrationBuilder.DropIndex(
                name: "IX_ProductoPresentacion_ProveedorId",
                table: "ProductoPresentacion");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "ProductoPresentacion");
        }
    }
}
