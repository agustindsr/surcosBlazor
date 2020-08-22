using Microsoft.EntityFrameworkCore.Migrations;

namespace SurcosBlazor.Server.Migrations
{
    public partial class userCajas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                table: "caja",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "userCaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(nullable: true),
                    CajaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userCaja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_userCaja_caja_CajaId",
                        column: x => x.CajaId,
                        principalTable: "caja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userCaja_CajaId",
                table: "userCaja",
                column: "CajaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userCaja");

            migrationBuilder.DropColumn(
                name: "enabled",
                table: "caja");
        }
    }
}
