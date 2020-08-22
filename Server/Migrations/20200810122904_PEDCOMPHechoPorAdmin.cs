using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class PEDCOMPHechoPorAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "hechoPorAdmin",
                table: "pedido",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hechoPorAdmin",
                table: "comprobante",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hechoPorAdmin",
                table: "pedido");

            migrationBuilder.DropColumn(
                name: "hechoPorAdmin",
                table: "comprobante");
        }
    }
}
