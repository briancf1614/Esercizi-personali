using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eliminar.Migrations
{
    /// <inheritdoc />
    public partial class RelacionProfessoreStudente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfessoreStudente",
                columns: table => new
                {
                    ProfessoresId = table.Column<int>(type: "int", nullable: false),
                    StudentiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessoreStudente", x => new { x.ProfessoresId, x.StudentiId });
                    table.ForeignKey(
                        name: "FK_ProfessoreStudente_Professori_ProfessoresId",
                        column: x => x.ProfessoresId,
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
