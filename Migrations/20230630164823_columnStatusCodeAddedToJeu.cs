using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperBowlWeb.Migrations
{
    /// <inheritdoc />
    public partial class columnStatusCodeAddedToJeu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "StatusCode",
                table: "Jeux",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusCode",
                table: "Jeux");
        }
    }
}
