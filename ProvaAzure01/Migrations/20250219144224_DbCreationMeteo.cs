using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProvaAzure01.Migrations
{
    /// <inheritdoc />
    public partial class DbCreationMeteo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nazione = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CittaPreferite",
                columns: table => new
                {
                    UtenteId = table.Column<int>(type: "int", nullable: false),
                    CittaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CittaPreferite", x => new { x.UtenteId, x.CittaId });
                    table.ForeignKey(
                        name: "FK_CittaPreferite_Citta_CittaId",
                        column: x => x.CittaId,
                        principalTable: "Citta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CittaPreferite_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CittaPreferite_CittaId",
                table: "CittaPreferite",
                column: "CittaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CittaPreferite");

            migrationBuilder.DropTable(
                name: "Citta");

            migrationBuilder.DropTable(
                name: "Utenti");
        }
    }
}
