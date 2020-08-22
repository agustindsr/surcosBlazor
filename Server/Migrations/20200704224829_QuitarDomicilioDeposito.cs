using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class QuitarDomicilioDeposito : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_deposito_domicilio_DomicilioId",
                table: "deposito");

            migrationBuilder.DropIndex(
                name: "IX_deposito_DomicilioId",
                table: "deposito");

            migrationBuilder.DropColumn(
                name: "DomicilioId",
                table: "deposito");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DomicilioId",
                table: "deposito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_deposito_DomicilioId",
                table: "deposito",
                column: "DomicilioId");

            migrationBuilder.AddForeignKey(
                name: "FK_deposito_domicilio_DomicilioId",
                table: "deposito",
                column: "DomicilioId",
                principalTable: "domicilio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
