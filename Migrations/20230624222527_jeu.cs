using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperBowlWeb.Migrations
{
    /// <inheritdoc />
    public partial class jeu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            

            migrationBuilder.CreateTable(
                name: "Jeux",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipeAId = table.Column<int>(type: "int", nullable: false),
                    EquipeBId = table.Column<int>(type: "int", nullable: false),
                    DateRencontre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeureDebut = table.Column<TimeSpan>(type: "time", nullable: true),
                    HeureFin = table.Column<TimeSpan>(type: "time", nullable: true),
                    ScoreEquipeA = table.Column<int>(type: "int", nullable: true),
                    ScoreEquipeB = table.Column<int>(type: "int", nullable: true),
                    EquipeGagnante = table.Column<int>(type: "int", nullable: true),
                    Commentaires = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jeux_Equipe_EquipeAId",
                        column: x => x.EquipeAId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Jeux_Equipe_EquipeBId",
                        column: x => x.EquipeBId,
                        principalTable: "Equipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

           migrationBuilder.CreateIndex(
                name: "IX_Jeux_EquipeAId",
                table: "Jeux",
                column: "EquipeAId");

            migrationBuilder.CreateIndex(
                name: "IX_Jeux_EquipeBId",
                table: "Jeux",
                column: "EquipeBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_Pays_PaysId",
                table: "Equipe",
                column: "PaysId",
                principalTable: "Pays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {          

                       
        }
    }
}
