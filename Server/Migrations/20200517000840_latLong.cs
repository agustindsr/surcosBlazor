using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class latLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "latitud",
                table: "domicilio",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "longitud",
                table: "domicilio",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "longitud",
                table: "domicilio");

            migrationBuilder.AlterColumn<string>(
                name: "latitud",
                table: "domicilio",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
