using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGenreColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 12, "Big ADVENTURE", "Adventure" },
                    { 14, "Big NERD", "Fantasy" },
                    { 16, "Big COMPUTERGRAPHIC", "Animation" },
                    { 18, "Big ARGUMENT", "Drama" },
                    { 27, "Big SCARE", "Horror" },
                    { 28, "Big BOOM", "Action" },
                    { 35, "Big LAUGH", "Comedy" },
                    { 36, "Big OLD MAN STORY", "History" },
                    { 37, "Big YEHAAAW", "Western" },
                    { 53, "Big MICHAEL JACKSON", "Thriller" },
                    { 80, "Big POLICE CHASE", "Crime" },
                    { 99, "Big REAL LIFE MOVIE", "Documentary" },
                    { 878, "Big SMARTS", "Science Fiction" },
                    { 9648, "Big HMM", "Mystery" },
                    { 10402, "Big UNTZ UNTZ", "Music" },
                    { 10749, "Big LOVE STORY", "Romance" },
                    { 10751, "Vin Diesel", "Family" },
                    { 10752, "Big PANG PANG", "War" },
                    { 10770, "Big MOVIE", "TV Movie" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 878);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9648);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10402);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10749);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10751);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10752);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10770);
        }
    }
}
