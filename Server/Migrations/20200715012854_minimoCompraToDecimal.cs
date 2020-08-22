using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class minimoCompraToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "minimoDeCompra",
                table: "tipoListaPrecio",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "minimoDeCompra",
                table: "tipoListaPrecio",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
