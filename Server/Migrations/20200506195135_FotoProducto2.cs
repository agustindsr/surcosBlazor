using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class FotoProducto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fotoigration",
                table: "producto");

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "producto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "producto");

            migrationBuilder.AddColumn<string>(
                name: "Fotoigration",
                table: "producto",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
