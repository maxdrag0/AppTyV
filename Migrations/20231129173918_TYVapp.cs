using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTyV.Migrations
{
    /// <inheritdoc />
    public partial class TYVapp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Partidos_PartidoId",
                table: "Jugadores");

            migrationBuilder.DropIndex(
                name: "IX_Jugadores_PartidoId",
                table: "Jugadores");

            migrationBuilder.DropColumn(
                name: "PartidoId",
                table: "Jugadores");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartidoId",
                table: "Jugadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Jugadores_PartidoId",
                table: "Jugadores",
                column: "PartidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Partidos_PartidoId",
                table: "Jugadores",
                column: "PartidoId",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
