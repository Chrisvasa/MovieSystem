using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieSystemAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ratings_PersonId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_PersonGenres_PersonId",
                table: "PersonGenres");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_MovieId",
                table: "MovieGenres");

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

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Fibbe@biffkatt.se", "Fibbe", "Biffkatt" },
                    { 2, "Hank@hill.usa", "Hank", "Hill" },
                    { 3, "Bob@mail.com", "Bob", "Mcbobson" },
                    { 4, "Tjurskalle@mail.com", "Ferdinand", "Tjurskalle" },
                    { 5, "Billy@mail.com", "Billy", "Willy" },
                    { 6, "Roger@mail.com", "Roger", "Pontare" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DateAdded", "Link", "PersonId", "Title" },
                values: new object[,]
                {
                    { 1, null, "https://www.themoviedb.org/movie/562-die-hard", 1, "Die Hard" },
                    { 2, null, "https://www.themoviedb.org/movie/245891-john-wick", 1, "John Wick" },
                    { 3, null, "https://www.themoviedb.org/movie/324552-john-wick-chapter-2", 3, "John Wick: Chapter 2" },
                    { 4, null, "https://www.themoviedb.org/movie/502356-the-super-mario-bros-movie", 4, "The Super Mario Bros. Movie" }
                });

            migrationBuilder.InsertData(
                table: "PersonGenres",
                columns: new[] { "Id", "GenreId", "PersonId" },
                values: new object[,]
                {
                    { 1, 28, 1 },
                    { 2, 35, 1 },
                    { 3, 80, 1 },
                    { 4, 28, 2 },
                    { 5, 35, 2 },
                    { 6, 12, 3 },
                    { 7, 10751, 3 },
                    { 8, 18, 4 },
                    { 9, 878, 4 }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "Id", "GenreId", "MovieId" },
                values: new object[,]
                {
                    { 1, 28, 1 },
                    { 2, 35, 1 },
                    { 3, 28, 2 },
                    { 4, 53, 2 },
                    { 5, 28, 3 },
                    { 6, 80, 3 },
                    { 7, 53, 3 },
                    { 8, 16, 4 },
                    { 9, 12, 4 },
                    { 10, 10751, 4 },
                    { 11, 14, 4 },
                    { 12, 35, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_PersonId_MovieId",
                table: "Ratings",
                columns: new[] { "PersonId", "MovieId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Email",
                table: "Persons",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonGenres_PersonId_GenreId",
                table: "PersonGenres",
                columns: new[] { "PersonId", "GenreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Link",
                table: "Movies",
                column: "Link",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MovieId_GenreId",
                table: "MovieGenres",
                columns: new[] { "MovieId", "GenreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ratings_PersonId_MovieId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Persons_Email",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_PersonGenres_PersonId_GenreId",
                table: "PersonGenres");

            migrationBuilder.DropIndex(
                name: "IX_Movies_Link",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_MovieGenres_MovieId_GenreId",
                table: "MovieGenres");

            migrationBuilder.DropIndex(
                name: "IX_Genres_Name",
                table: "Genres");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 27);

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
                keyValue: 99);

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
                keyValue: 10752);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10770);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PersonGenres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonGenres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonGenres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonGenres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PersonGenres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PersonGenres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PersonGenres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PersonGenres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PersonGenres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 6);

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
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 35);

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
                keyValue: 878);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10751);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_PersonId",
                table: "Ratings",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGenres_PersonId",
                table: "PersonGenres",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenres_MovieId",
                table: "MovieGenres",
                column: "MovieId");
        }
    }
}
