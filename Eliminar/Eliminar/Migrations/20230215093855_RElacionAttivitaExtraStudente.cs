using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eliminar.Migrations
{
    /// <inheritdoc />
    public partial class RElacionAttivitaExtraStudente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttivitaExtracurricolariStudente",
                columns: table => new
                {
                    AttivitaExtraId = table.Column<int>(type: "int", nullable: false),
                    StudentiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttivitaExtracurricolariStudente", x => new { x.AttivitaExtraId, x.StudentiId });
                    table.ForeignKey(
                        name: "FK_AttivitaExtracurricolariStudente_AttivitaExtra_AttivitaExtra~",
                        column: x => x.AttivitaExtraId,
                        principalTable: "AttivitaExtra",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttivitaExtracurricolariStudente_Studenti_StudentiId",
                        column: x => x.StudentiId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AttivitaExtracurricolariStudente_StudentiId",
                table: "AttivitaExtracurricolariStudente",
                column: "StudentiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttivitaExtracurricolariStudente");
        }
    }
}
