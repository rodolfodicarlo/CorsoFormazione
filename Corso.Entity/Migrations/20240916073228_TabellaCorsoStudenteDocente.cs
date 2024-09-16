using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corso.Entity.Migrations
{
    /// <inheritdoc />
    public partial class TabellaCorsoStudenteDocente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Docente",
                columns: table => new
                {
                    IDDocente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docente", x => x.IDDocente);
                });

            migrationBuilder.CreateTable(
                name: "Studente",
                columns: table => new
                {
                    IDStudente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Matricola = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studente", x => x.IDStudente);
                });

            migrationBuilder.CreateTable(
                name: "Corso",
                columns: table => new
                {
                    IDCorso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDDocente = table.Column<int>(type: "int", nullable: false),
                    IDAula = table.Column<int>(type: "int", nullable: false),
                    NomeCorso = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Durata = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DataInizio = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corso", x => x.IDCorso);
                    table.ForeignKey(
                        name: "FK_Corso_Aula_IDAula",
                        column: x => x.IDAula,
                        principalTable: "Aula",
                        principalColumn: "Idaula",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Corso_Docente_IDDocente",
                        column: x => x.IDDocente,
                        principalTable: "Docente",
                        principalColumn: "IDDocente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Corso_IDAula",
                table: "Corso",
                column: "IDAula");

            migrationBuilder.CreateIndex(
                name: "IX_Corso_IDDocente",
                table: "Corso",
                column: "IDDocente");

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
