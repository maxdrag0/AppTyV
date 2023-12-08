using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppTyV.Migrations
{
    /// <inheritdoc />
    public partial class RelationSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Partidos_PartidoId",
                table: "Jugadores");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Partidos_PartidoId",
                table: "Jugadores",
                column: "PartidoId",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jugadores_Partidos_PartidoId",
                table: "Jugadores");

            migrationBuilder.AddForeignKey(
                name: "FK_Jugadores_Partidos_PartidoId",
                table: "Jugadores",
                column: "PartidoId",
                principalTable: "Partidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
