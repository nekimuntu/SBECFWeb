using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperBowlWeb.Migrations
{
    /// <inheritdoc />
    public partial class addedColumnMeteoJeu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Meteo",
                table: "Jeux",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meteo",
                table: "Jeux");
        }
    }
}
