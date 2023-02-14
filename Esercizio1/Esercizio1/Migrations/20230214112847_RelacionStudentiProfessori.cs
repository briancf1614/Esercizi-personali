using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esercizio1.Migrations
{
    /// <inheritdoc />
    public partial class RelacionStudentiProfessori : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfessoreStudente",
                columns: table => new
                {
                    ProfessoriId = table.Column<int>(type: "int", nullable: false),
                    StudentiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessoreStudente", x => new { x.ProfessoriId, x.StudentiId });
                    table.ForeignKey(
                        name: "FK_ProfessoreStudente_Professori_ProfessoriId",
                        column: x => x.ProfessoriId,
                        principalTable: "Professori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfessoreStudente_Studenti_StudentiId",
                        column: x => x.StudentiId,
                        principalTable: "Studenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessoreStudente_StudentiId",
                table: "ProfessoreStudente",
                column: "StudentiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessoreStudente");
        }
    }
}
