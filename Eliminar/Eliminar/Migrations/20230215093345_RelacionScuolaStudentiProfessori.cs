using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eliminar.Migrations
{
    /// <inheritdoc />
    public partial class RelacionScuolaStudentiProfessori : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScuolaId",
                table: "Studenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScuolaId",
                table: "Professori",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Studenti_ScuolaId",
                table: "Studenti",
                column: "ScuolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Professori_ScuolaId",
                table: "Professori",
                column: "ScuolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Professori_Scuola_ScuolaId",
                table: "Professori",
                column: "ScuolaId",
                principalTable: "Scuola",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Studenti_Scuola_ScuolaId",
                table: "Studenti",
                column: "ScuolaId",
                principalTable: "Scuola",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Professori_Scuola_ScuolaId",
                table: "Professori");

            migrationBuilder.DropForeignKey(
                name: "FK_Studenti_Scuola_ScuolaId",
                table: "Studenti");

            migrationBuilder.DropIndex(
                name: "IX_Studenti_ScuolaId",
                table: "Studenti");

            migrationBuilder.DropIndex(
                name: "IX_Professori_ScuolaId",
                table: "Professori");

            migrationBuilder.DropColumn(
                name: "ScuolaId",
                table: "Studenti");

            migrationBuilder.DropColumn(
                name: "ScuolaId",
                table: "Professori");
        }
    }
}
