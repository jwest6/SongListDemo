using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SongList.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixSongEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Singer",
                table: "Songs",
                newName: "SongNumber");

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Songs");

            migrationBuilder.RenameColumn(
                name: "SongNumber",
                table: "Songs",
                newName: "Singer");
        }
    }
}
