using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EpisodeFinder.Database.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TmdbId",
                table: "Series",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlexRatingKey",
                table: "Seasons",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeasonName",
                table: "Seasons",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlexRatingKey",
                table: "Episodes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlexRatingKey",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "SeasonName",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "PlexRatingKey",
                table: "Episodes");

            migrationBuilder.AlterColumn<int>(
                name: "TmdbId",
                table: "Series",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
