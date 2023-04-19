using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedMovieColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Movies",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Movies",
                newName: "Name");
        }
    }
}
