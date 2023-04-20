using Microsoft.EntityFrameworkCore;
using MovieSystem.DataAccess;
using MovieSystem.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Runtime.CompilerServices;

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


        // Hämta alla personer i systemet -- CHECK
        app.MapGet("/api/Persons/", async (DataContext context) => await context.Persons.ToListAsync());

        // Hämta alla genrer som är kopplade till en specifik person -- CHECK
        app.MapGet("/api/Genres/FilterByPerson", async (DataContext context, string Name) =>
        {
            var test = from person in context.PersonGenres
                       select new
                       {
                           person.Person.FirstName,
                           person.Genre.Name
                       };
            var result = test.GroupBy(x => x.FirstName)
                    .Select(x => new { Name = x.Key, LikedGenres = string.Join(", ", x.Select(y => y.Name)) })
                    .Where(x => x.Name == Name).ToListAsync();
            return await result;
        });

        // Hämta matchande filmer till eftersökta genren -- CHECK
        app.MapGet("/api/Genres/FilterByGenre", async (DataContext context, string Name) =>
        {
            var test = from mg in context.MovieGenres
                       select new
                       {
                           mg.Movie.Title,
                           mg.Genre.Name,
                           mg.Movie.Link
                       };
            var result = test.GroupBy(x => x.Name).OrderBy(x => x.Key)
                    .Select(x => new { Genre = x.Key, Matches = string.Join(", ", x.Select(y => y.Title)), Links = x.Select(z => z.Link) })
                    .Where(x => x.Genre == Name).ToListAsync();
            return await result;
        });

        //Hämta alla filmer som är kopplade till en specifik person
        app.MapGet("/api/Movies/GetMoviesForPerson", async (DataContext context, string Name) =>
        {
            var test = from m in context.Movies
                       select new
                       {
                           m.Person.FirstName,
                           m.Title
                       };
            return await test.Where(x => x.FirstName.Contains(Name)).ToListAsync();
        });
        // Hämta "rating" på filmer kopplat till en person
        app.MapGet("/api/Ratings/GetRatingsForPerson", async (DataContext context, string Name) =>
        {
            var test = from r in context.Ratings
                       select new
                       {
                           r.Person.FirstName,
                           MovieTitle = r.Movie.Title,
                           r.MovieRating
                       };
            var result = test.GroupBy(x => x.FirstName).OrderBy(x => x.Key)
                    .Select(x => new { Person = x.Key, MoviesRatings = string.Join(',', x.Select(y => y.MovieTitle + " - Rating: " +  y.MovieRating)).Split(',', StringSplitOptions.None)})
                    .Where(x => x.Person == Name).ToListAsync();
            return await result;
        });

        // Lägga in "rating" på filmer kopplat till en person
        app.MapPost("/api/ratings/addrating", async (DataContext context, int movieId, int movieRating, int personId) =>
        {
            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null)
            {
                return Results.NotFound();
            }
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

        // Koppla en person till en ny genre
        app.MapPost("/api/Genre/AddPersonToGenre", async (DataContext context, int personId, int genreId) =>
        {
            var person = await context.Persons.FirstOrDefaultAsync(p => p.Id == personId);
            if (person == null)
            {
                return Results.NotFound();
            }
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

        // Lägga in nya länkar för en specifik person och en specifik genre
        app.MapPost("/api/Movies/Add", async (DataContext context, string title, string link, string genres) =>
        {

        });

        // Få förslag på filmer i en viss genre från ett externt API, t.ex TMDB. 

        //Get Person by Name
        //app.MapGet("/api/Persons/{firstName}", async (DataContext context, string firstName) =>
        //    await context.Persons.FindAsync(firstName) is Person person ? Results.Ok(person) : Results.NotFound("Person not found ./"));

        app.Run();
    }
}