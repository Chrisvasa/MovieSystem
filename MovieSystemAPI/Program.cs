using Microsoft.EntityFrameworkCore;
using MovieSystem.DataAccess;
using MovieSystem.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.ComponentModel.Design.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //Connection string
        builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();


        // Gets all the users in the DB
        app.MapGet("/api/Persons/", async (DataContext context) => await context.Persons.ToListAsync());

        // Gets all the liked genres from the given person
        app.MapGet("/api/Genres/FilterByPerson", async (DataContext context, string Name) =>
        {
            var genres = from person in context.PersonGenres
                       select new
                       {
                           person.Person.FirstName,
                           person.Genre.Name
                       };
            // This groups up the genres and adds them together, which gives us a nicer format in the JSON file
            var result = genres.GroupBy(x => x.FirstName)
                    .Select(x => new { Name = x.Key, LikedGenres = string.Join(", ", x.Select(y => y.Name)) })
                    .Where(x => x.Name == Name).ToListAsync();
            return await result;
        });

        // Gets all the movies with the given genre
        app.MapGet("/api/Genres/FilterByGenre", async (DataContext context, string Name) =>
        {
            var movies = from mg in context.MovieGenres
                       select new
                       {
                           mg.Movie.Title,
                           mg.Genre.Name,
                           mg.Movie.Link
                       };
            // This groups up the movies and adds them together, which gives us a nicer format in the JSON file
            var result = movies.GroupBy(x => x.Name).OrderBy(x => x.Key)
                    .Select(x => new { Genre = x.Key, Matches = string.Join(", ", x.Select(y => y.Title)), Links = x.Select(z => z.Link) })
                    .Where(x => x.Genre == Name).ToListAsync();
            return await result;
        });

        //H�mta alla filmer som �r kopplade till en specifik person
        // Gets all the movies that a user has added to the database
        app.MapGet("/api/Movies/GetMoviesForPerson", async (DataContext context, string Name) =>
        {
            var movies = from m in context.Movies
                       select new
                       {
                           m.Person.FirstName,
                           m.Title
                       };
            // Gets all the matching persons 
            // EX. f will return all names containing f such as Fibbe
            return await movies.Where(x => x.FirstName.Contains(Name)).ToListAsync();
        });

        // Gets all the movies a specific person has rated
        app.MapGet("/api/Ratings/GetRatingsForPerson", async (DataContext context, string Name) =>
        {
            var ratings = from r in context.Ratings
                       select new
                       {
                           r.Person.FirstName,
                           MovieTitle = r.Movie.Title,
                           r.MovieRating
                       };
            // This groups up the ratings and adds them together, which gives us a nicer format in the JSON file
            var result = ratings.GroupBy(x => x.FirstName).OrderBy(x => x.Key)
                    .Select(x => new { Person = x.Key, MoviesRatings = string.Join(',', x.Select(y => y.MovieTitle + " - Rating: " +  y.MovieRating)).Split(',', StringSplitOptions.None)})
                    .Where(x => x.Person == Name).ToListAsync();
            return await result;
        });

        // Method to allow users to rate movies
        app.MapPost("/api/ratings/addrating", async (DataContext context, int movieId, int movieRating, int personId) =>
        {
            // Checks if the movie exists in the DB
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                return Results.NotFound();
            }
            // Checks if the person exists in the DB
            var person = await context.Persons.FirstOrDefaultAsync(p => p.Id == personId);
            if (person == null)
            {
                return Results.NotFound();
            }

            var rating = new Rating
            {
                MovieId = movie.Id,
                MovieRating = movieRating,
                PersonId = person.Id
            };

            context.Ratings.Add(rating);
            await context.SaveChangesAsync();
            return Results.Created($"/api/ratings/addrating", rating);

        });

        // Method to connect users to genres
        app.MapPost("/api/Genre/AddPersonToGenre", async (DataContext context, int personId, int genreId) =>
        {
            // Checks if the user exists in the DB
            var person = await context.Persons.FirstOrDefaultAsync(p => p.Id == personId);
            if (person == null)
            {
                return Results.NotFound();
            }
            // Checks if the genre exists in the DB
            var genre = await context.Genres.FirstOrDefaultAsync(g => g.Id == genreId);
            if (genre == null)
            {
                return Results.NotFound();
            }

            var persongenre = new PersonGenre
            {
                PersonId = person.Id,
                GenreId = genreId
            };

            context.PersonGenres.Add(persongenre);
            await context.SaveChangesAsync();
            return Results.Created($"/api/Genre/AddPersonToGenre", persongenre);
        });

        // Adds a movie with a title, link and the person who added it to the database
        // Also adds the given Genres to the movie in the MovieGenre Table
        app.MapPost("/api/Movies/Add", async (DataContext context, string title, string link, string genres, int personId) =>
        {
            // Splits the genres into an array
            string[] arrGenres = genres.Split(',');
            var person = await context.Persons.FirstOrDefaultAsync(p => p.Id == personId);
            if (person == null)
            {
                return Results.NotFound();
            }
            // Adds the movie to the database with the given input
            var movie = new Movie
            {
                Title = title,
                Link = link,
                PersonId = person.Id
            };
            context.Movies.Add(movie);
            await context.SaveChangesAsync();

            // Gets the newly added movieID from the database to correctly add the genres
            int movieId = context.Movies.First(am => am.Title == movie.Title).Id;
            for (int i = 0; i < arrGenres.Length; i++)
            {
                var movieGenre = new MovieGenre
                {
                    // Gets the genreID that belongs to the given genre
                    GenreId = context.Genres.First(g => g.Name.Contains(arrGenres[i])).Id,
                    MovieId = movieId
                };
                context.MovieGenres.Add(movieGenre);
                await context.SaveChangesAsync();
            };
            return Results.Created($"/api/Movies/Add", movie);
        });

        // This method allows the user to discover new movies that they might like by getting the genreID from the DB
        // Then connecting that to the API from themoviedb.org and returning the results in JSON format
        app.MapGet("/api/Movies/Suggestions", async (DataContext context, string genre) =>
        {
            // Gets the correct genreID that tmdb uses
            int genreID = context.Genres.First(x => x.Name.Contains(genre)).Id;
            // The API key to use for TMDB - Input your own here
            string apiKey = "d82f364f4fa13e9d2bc3e63a48f37d0c";
            string url = $"https://api.themoviedb.org/3/discover/movie?api_key={apiKey}&language=en-US&sort_by=vote_count.desc&include_adult=false&include_video=false&page=1&with_genres={genreID}&with_watch_monetization_types=flatrate";

            var client = new HttpClient();
            var response = await client.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();
            // Returns the results in JSON instead of raw data
            return Results.Content(content, contentType: "application/json");
        });
        app.Run();
    }
}