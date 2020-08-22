using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class Clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cuit",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "nombreComercial",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "razonSocial",
                table: "clientes");

            migrationBuilder.AddColumn<string>(
                name: "apellido",
                table: "clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "celular",
                table: "clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fechaNacimiento",
                table: "clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombre",
                table: "clientes",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "apellido",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "celular",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "email",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "fechaNacimiento",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "nombre",
                table: "clientes");

            migrationBuilder.AddColumn<string>(
                name: "cuit",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nombreComercial",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "razonSocial",
                table: "clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
