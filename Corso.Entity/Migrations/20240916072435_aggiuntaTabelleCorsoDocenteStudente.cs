using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corso.Entity.Migrations
{
    /// <inheritdoc />
    public partial class aggiuntaTabelleCorsoDocenteStudente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    Iddocente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.Iddocente);
                });

            migrationBuilder.CreateTable(
                name: "Studente",
                columns: table => new
                {
                    Idstudente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Matricola = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studente", x => x.Idstudente);
                });

            migrationBuilder.CreateTable(
                name: "Corso",
                columns: table => new
                {
                    Idcorso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iddocente = table.Column<int>(type: "int", nullable: false),
                    Idaula = table.Column<int>(type: "int", nullable: false),
                    NomeCorso = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Durata = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataInizio = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corso", x => x.Idcorso);
                    table.ForeignKey(
                        name: "FK_Corso_Aula_Idaula",
                        column: x => x.Idaula,
                        principalTable: "Aula",
                        principalColumn: "Idaula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Corso_Docente_Iddocente",
                        column: x => x.Iddocente,
                        principalTable: "Docente",
                        principalColumn: "Iddocente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corso_Idaula",
                table: "Corso",
                column: "Idaula");

            migrationBuilder.CreateIndex(
                name: "IX_Corso_Iddocente",
                table: "Corso",
                column: "Iddocente");

            migrationBuilder.CreateIndex(
                name: "IX_Studente_Matricola",
                table: "Studente",
                column: "Matricola",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Corso");

            migrationBuilder.DropTable(
                name: "Studente");

            migrationBuilder.DropTable(
                name: "Docente");
        }
    }
}
