using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class IdentityChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estadoListaPrecios");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendedorId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClienteId",
                table: "AspNetUsers",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VendedorId",
                table: "AspNetUsers",
                column: "VendedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_clientes_ClienteId",
                table: "AspNetUsers",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_vendedor_VendedorId",
                table: "AspNetUsers",
                column: "VendedorId",
                principalTable: "vendedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_clientes_ClienteId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_vendedor_VendedorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClienteId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VendedorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VendedorId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "estadoListaPrecios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoListaPrecios", x => x.Id);
                });
        }
    }
}
