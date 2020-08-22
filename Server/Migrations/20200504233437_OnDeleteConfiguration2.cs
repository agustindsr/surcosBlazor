using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class OnDeleteConfiguration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departamento_provincias_ProvinciaId",
                table: "departamento");

            migrationBuilder.DropForeignKey(
                name: "FK_domicilio_provincias_ProvinciaId",
                table: "domicilio");

            migrationBuilder.AddForeignKey(
                name: "FK_departamento_provincias_ProvinciaId",
                table: "departamento",
                column: "ProvinciaId",
                principalTable: "provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_domicilio_provincias_ProvinciaId",
                table: "domicilio",
                column: "ProvinciaId",
                principalTable: "provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departamento_provincias_ProvinciaId",
                table: "departamento");

            migrationBuilder.DropForeignKey(
                name: "FK_domicilio_provincias_ProvinciaId",
                table: "domicilio");

            migrationBuilder.AddForeignKey(
                name: "FK_departamento_provincias_ProvinciaId",
                table: "departamento",
                column: "ProvinciaId",
                principalTable: "provincias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_domicilio_provincias_ProvinciaId",
                table: "domicilio",
                column: "ProvinciaId",
                principalTable: "provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
