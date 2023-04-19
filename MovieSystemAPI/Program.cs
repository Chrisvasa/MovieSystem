using Microsoft.EntityFrameworkCore;
using MovieSystem.DataAccess;
using MovieSystem.Models;

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


// Hämta alla personer i systemet
app.MapGet("/api/Persons/", async (DataContext context) => await context.Persons.ToListAsync());

// Hämta alla genrer som är kopplade till en specifik person
app.MapGet("/api/Genres/{firstName}", async (DataContext context, string Name) =>
{
    var test = from person in context.PersonGenres
               select new
               {
                   person.Person.FirstName,
                   person.Genre.Name
               };
    var result = test.GroupBy(x => x.FirstName)
            .Select(x => new { Name = x.Key, LikedGenres = string.Join(", ", x.Select(y => y.Name))})
            .Where(x => x.Name == Name).ToListAsync();
    return await result;
});

// Hämta alla filmer som är kopplade till en specifik person
app.MapGet("/api/Movies/{genreName}", async (DataContext context, string Name) =>
{
    var test = from mg in context.MovieGenres
               select new
               {
                   mg.Movie.Title,
                   mg.Genre.Name
               };
    var result = test.GroupBy(x => x.Name)
            .Select(x => new { Genre = x.Key, Matches = string.Join(", ", x.Select(y => y.Title)) })
            .Where(x => x.Genre == Name).ToListAsync();
    return await result;
});
//app.MapGet("/api/Movies/{firstName}", async (DataContext context, string Name) =>
//{
//    var movies = context.Movies;
//    var moviePerson = movies.Join(context.Persons, movie => movie.PersonId,
//        per => per.Id, (movie, per) => new
//        {
//            movie.Name,
//            movie.Link,
//            movie.DateAdded,
//            per.FirstName,
//            per.LastName
//        }).Where(x => x.FirstName == Name).OrderBy(x => x.Name).ToListAsync();
//    return await moviePerson;
//});

// Lägga in och hämta "rating" på filmer kopplat till en person

// Koppla en person till en ny genre

// Lägga in nya länkar för en specifik person och en specifik genre

// Få förslag på filmer i en viss genre från ett externt API, t.ex TMDB. 

//Get Person by Name
//app.MapGet("/api/Persons/{firstName}", async (DataContext context, string firstName) =>
//    await context.Persons.FindAsync(firstName) is Person person ? Results.Ok(person) : Results.NotFound("Person not found ./"));

app.Run();