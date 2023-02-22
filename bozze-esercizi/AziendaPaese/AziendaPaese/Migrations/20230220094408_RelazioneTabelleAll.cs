using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AziendaPaese.Migrations
{
    /// <inheritdoc />
    public partial class RelazioneTabelleAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RepartoId",
                table: "SupervisoriReparto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RepartoId",
                table: "Stagisti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DipendenteId",
                table: "ReportiGiornalieri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StagistaId",
                table: "ReportiGiornalieri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupervisoreRepartoId",
                table: "ReportiGiornalieri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AziendaId",
                table: "Reparti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupervisoreRepartoId",
                table: "Reparti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProgettoId",
                table: "Dipendenti",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepartoId",
                table: "Dipendenti",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DipendenteId",
                table: "Bustepaghe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StagistaId",
                table: "Bustepaghe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupervisoreRepartoId",
                table: "Bustepaghe",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProgettoStagista",
                columns: table => new
                {
                    ProgettiId = table.Column<int>(type: "int", nullable: false),
                    StagistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgettoStagista", x => new { x.ProgettiId, x.StagistaId });
                    table.ForeignKey(
                        name: "FK_ProgettoStagista_Progetti_ProgettiId",
                        column: x => x.ProgettiId,
                        principalTable: "Progetti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgettoStagista_Stagisti_StagistaId",
                        column: x => x.StagistaId,
                        principalTable: "Stagisti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Stagisti_RepartoId",
                table: "Stagisti",
                column: "RepartoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportiGiornalieri_DipendenteId",
                table: "ReportiGiornalieri",
                column: "DipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportiGiornalieri_StagistaId",
                table: "ReportiGiornalieri",
                column: "StagistaId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportiGiornalieri_SupervisoreRepartoId",
                table: "ReportiGiornalieri",
                column: "SupervisoreRepartoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparti_AziendaId",
                table: "Reparti",
                column: "AziendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparti_SupervisoreRepartoId",
                table: "Reparti",
                column: "SupervisoreRepartoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dipendenti_ProgettoId",
                table: "Dipendenti",
                column: "ProgettoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dipendenti_RepartoId",
                table: "Dipendenti",
                column: "RepartoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bustepaghe_DipendenteId",
                table: "Bustepaghe",
                column: "DipendenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Bustepaghe_StagistaId",
                table: "Bustepaghe",
                column: "StagistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bustepaghe_SupervisoreRepartoId",
                table: "Bustepaghe",
                column: "SupervisoreRepartoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgettoStagista_StagistaId",
                table: "ProgettoStagista",
                column: "StagistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bustepaghe_Dipendenti_DipendenteId",
                table: "Bustepaghe",
                column: "DipendenteId",
                principalTable: "Dipendenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bustepaghe_Stagisti_StagistaId",
                table: "Bustepaghe",
                column: "StagistaId",
                principalTable: "Stagisti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bustepaghe_SupervisoriReparto_SupervisoreRepartoId",
                table: "Bustepaghe",
                column: "SupervisoreRepartoId",
                principalTable: "SupervisoriReparto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dipendenti_Progetti_ProgettoId",
                table: "Dipendenti",
                column: "ProgettoId",
                principalTable: "Progetti",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dipendenti_Reparti_RepartoId",
                table: "Dipendenti",
                column: "RepartoId",
                principalTable: "Reparti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparti_Aziende_AziendaId",
                table: "Reparti",
                column: "AziendaId",
                principalTable: "Aziende",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reparti_SupervisoriReparto_SupervisoreRepartoId",
                table: "Reparti",
                column: "SupervisoreRepartoId",
                principalTable: "SupervisoriReparto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportiGiornalieri_Dipendenti_DipendenteId",
                table: "ReportiGiornalieri",
                column: "DipendenteId",
                principalTable: "Dipendenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportiGiornalieri_Stagisti_StagistaId",
                table: "ReportiGiornalieri",
                column: "StagistaId",
                principalTable: "Stagisti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportiGiornalieri_SupervisoriReparto_SupervisoreRepartoId",
                table: "ReportiGiornalieri",
                column: "SupervisoreRepartoId",
                principalTable: "SupervisoriReparto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stagisti_Reparti_RepartoId",
                table: "Stagisti",
                column: "RepartoId",
                principalTable: "Reparti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bustepaghe_Dipendenti_DipendenteId",
                table: "Bustepaghe");

            migrationBuilder.DropForeignKey(
                name: "FK_Bustepaghe_Stagisti_StagistaId",
                table: "Bustepaghe");

            migrationBuilder.DropForeignKey(
                name: "FK_Bustepaghe_SupervisoriReparto_SupervisoreRepartoId",
                table: "Bustepaghe");

            migrationBuilder.DropForeignKey(
                name: "FK_Dipendenti_Progetti_ProgettoId",
                table: "Dipendenti");

            migrationBuilder.DropForeignKey(
                name: "FK_Dipendenti_Reparti_RepartoId",
                table: "Dipendenti");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparti_Aziende_AziendaId",
                table: "Reparti");

            migrationBuilder.DropForeignKey(
                name: "FK_Reparti_SupervisoriReparto_SupervisoreRepartoId",
                table: "Reparti");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportiGiornalieri_Dipendenti_DipendenteId",
                table: "ReportiGiornalieri");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportiGiornalieri_Stagisti_StagistaId",
                table: "ReportiGiornalieri");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportiGiornalieri_SupervisoriReparto_SupervisoreRepartoId",
                table: "ReportiGiornalieri");

            migrationBuilder.DropForeignKey(
                name: "FK_Stagisti_Reparti_RepartoId",
                table: "Stagisti");

            migrationBuilder.DropTable(
                name: "ProgettoStagista");

            migrationBuilder.DropIndex(
                name: "IX_Stagisti_RepartoId",
                table: "Stagisti");

            migrationBuilder.DropIndex(
                name: "IX_ReportiGiornalieri_DipendenteId",
                table: "ReportiGiornalieri");

            migrationBuilder.DropIndex(
                name: "IX_ReportiGiornalieri_StagistaId",
                table: "ReportiGiornalieri");

            migrationBuilder.DropIndex(
                name: "IX_ReportiGiornalieri_SupervisoreRepartoId",
                table: "ReportiGiornalieri");

            migrationBuilder.DropIndex(
                name: "IX_Reparti_AziendaId",
                table: "Reparti");

            migrationBuilder.DropIndex(
                name: "IX_Reparti_SupervisoreRepartoId",
                table: "Reparti");

            migrationBuilder.DropIndex(
                name: "IX_Dipendenti_ProgettoId",
                table: "Dipendenti");

            migrationBuilder.DropIndex(
                name: "IX_Dipendenti_RepartoId",
                table: "Dipendenti");

            migrationBuilder.DropIndex(
                name: "IX_Bustepaghe_DipendenteId",
                table: "Bustepaghe");

            migrationBuilder.DropIndex(
                name: "IX_Bustepaghe_StagistaId",
                table: "Bustepaghe");

            migrationBuilder.DropIndex(
                name: "IX_Bustepaghe_SupervisoreRepartoId",
                table: "Bustepaghe");

            migrationBuilder.DropColumn(
                name: "RepartoId",
                table: "SupervisoriReparto");

            migrationBuilder.DropColumn(
                name: "RepartoId",
                table: "Stagisti");

            migrationBuilder.DropColumn(
                name: "DipendenteId",
                table: "ReportiGiornalieri");

            migrationBuilder.DropColumn(
                name: "StagistaId",
                table: "ReportiGiornalieri");

            migrationBuilder.DropColumn(
                name: "SupervisoreRepartoId",
                table: "ReportiGiornalieri");

            migrationBuilder.DropColumn(
                name: "AziendaId",
                table: "Reparti");

            migrationBuilder.DropColumn(
                name: "SupervisoreRepartoId",
                table: "Reparti");

            migrationBuilder.DropColumn(
                name: "ProgettoId",
                table: "Dipendenti");

            migrationBuilder.DropColumn(
                name: "RepartoId",
                table: "Dipendenti");

            migrationBuilder.DropColumn(
                name: "DipendenteId",
                table: "Bustepaghe");

            migrationBuilder.DropColumn(
                name: "StagistaId",
                table: "Bustepaghe");

            migrationBuilder.DropColumn(
                name: "SupervisoreRepartoId",
                table: "Bustepaghe");
        }
    }
}
