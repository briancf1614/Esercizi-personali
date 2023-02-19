using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace EsempioDaButare.Migrations
{
    /// <inheritdoc />
    public partial class InizialConRelazioni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dipendenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NomeCompleto = table.Column<string>(type: "longtext", nullable: false),
                    GuadagniAnnuali = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Anni = table.Column<int>(type: "int", nullable: false),
                    AnniEsperienza = table.Column<int>(type: "int", nullable: false),
                    LavoraAncora = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataAsunzione = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dipendenti", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Paesi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Live = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataIndependenza = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    soldi = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paesi", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stagisti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Anni = table.Column<int>(type: "int", nullable: false),
                    SoldiRicevutiInPeriodoStage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InizioStage = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FineStage = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stagisti", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Supervisori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NomeCompleto = table.Column<string>(type: "longtext", nullable: false),
                    AnniEsperienza = table.Column<int>(type: "int", nullable: false),
                    LavoraAncora = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervisori", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DipendenteReparto",
                columns: table => new
                {
                    DipendentiId = table.Column<int>(type: "int", nullable: false),
                    RepartiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DipendenteReparto", x => new { x.DipendentiId, x.RepartiId });
                    table.ForeignKey(
                        name: "FK_DipendenteReparto_Dipendenti_DipendentiId",
                        column: x => x.DipendentiId,
                        principalTable: "Dipendenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Diretore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Anni = table.Column<int>(type: "int", nullable: false),
                    DataInizio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FabricaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diretore", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fabriche",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false),
                    GuadagniAnnuali = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataFondazione = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    OperativaAncora = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PaeseId = table.Column<int>(type: "int", nullable: false),
                    Diretoreid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabriche", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fabriche_Diretore_Diretoreid",
                        column: x => x.Diretoreid,
                        principalTable: "Diretore",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fabriche_Paesi_PaeseId",
                        column: x => x.PaeseId,
                        principalTable: "Paesi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reparti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NomeReparto = table.Column<string>(type: "longtext", nullable: false),
                    CapacitaDiLavoratori = table.Column<int>(type: "int", nullable: false),
                    FabricaId = table.Column<int>(type: "int", nullable: false),
                    SupervisoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reparti_Fabriche_FabricaId",
                        column: x => x.FabricaId,
                        principalTable: "Fabriche",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reparti_Supervisori_SupervisoreId",
                        column: x => x.SupervisoreId,
                        principalTable: "Supervisori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RepartoStagista",
                columns: table => new
                {
                    RepartiId = table.Column<int>(type: "int", nullable: false),
                    StagistiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepartoStagista", x => new { x.RepartiId, x.StagistiId });
                    table.ForeignKey(
                        name: "FK_RepartoStagista_Reparti_RepartiId",
                        column: x => x.RepartiId,
                        principalTable: "Reparti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepartoStagista_Stagisti_StagistiId",
                        column: x => x.StagistiId,
                        principalTable: "Stagisti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DipendenteReparto_RepartiId",
                table: "DipendenteReparto",
                column: "RepartiId");

            migrationBuilder.CreateIndex(
                name: "IX_Diretore_FabricaId",
                table: "Diretore",
                column: "FabricaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabriche_Diretoreid",
                table: "Fabriche",
                column: "Diretoreid");

            migrationBuilder.CreateIndex(
                name: "IX_Fabriche_PaeseId",
                table: "Fabriche",
                column: "PaeseId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparti_FabricaId",
                table: "Reparti",
                column: "FabricaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reparti_SupervisoreId",
                table: "Reparti",
                column: "SupervisoreId");

            migrationBuilder.CreateIndex(
                name: "IX_RepartoStagista_StagistiId",
                table: "RepartoStagista",
                column: "StagistiId");

            migrationBuilder.AddForeignKey(
                name: "FK_DipendenteReparto_Reparti_RepartiId",
                table: "DipendenteReparto",
                column: "RepartiId",
                principalTable: "Reparti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diretore_Fabriche_FabricaId",
                table: "Diretore",
                column: "FabricaId",
                principalTable: "Fabriche",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diretore_Fabriche_FabricaId",
                table: "Diretore");

            migrationBuilder.DropTable(
                name: "DipendenteReparto");

            migrationBuilder.DropTable(
                name: "RepartoStagista");

            migrationBuilder.DropTable(
                name: "Dipendenti");

            migrationBuilder.DropTable(
                name: "Reparti");

            migrationBuilder.DropTable(
                name: "Stagisti");

            migrationBuilder.DropTable(
                name: "Supervisori");

            migrationBuilder.DropTable(
                name: "Fabriche");

            migrationBuilder.DropTable(
                name: "Diretore");

            migrationBuilder.DropTable(
                name: "Paesi");
        }
    }
}
