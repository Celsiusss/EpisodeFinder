using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpisodeFinder.Database.Migrations
{
    /// <inheritdoc />
    public partial class monitoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Monitoring",
                table: "Seasons",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Monitoring",
                table: "Seasons");
        }
    }
}
