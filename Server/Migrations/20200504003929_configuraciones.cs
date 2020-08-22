using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class configuraciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "habilitado",
                table: "clientes");

            migrationBuilder.AlterColumn<double>(
                name: "saldoCC",
                table: "clientes",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "clientes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "enabled",
                table: "clientes");

            migrationBuilder.AlterColumn<float>(
                name: "saldoCC",
                table: "clientes",
                type: "real",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<bool>(
                name: "habilitado",
                table: "clientes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
