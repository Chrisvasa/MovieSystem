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


// H�mta alla personer i systemet -- CHECK
app.MapGet("/api/Persons/", async (DataContext context) => await context.Persons.ToListAsync());

// H�mta alla genrer som �r kopplade till en specifik person -- CHECK
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

// H�mta matchande filmer till efters�kta genren -- CHECK
app.MapGet("/api/Genres/", async (DataContext context, string Name) =>
{
    var test = from mg in context.MovieGenres
               select new
               {
                   mg.Movie.Title,
                   mg.Genre.Name,
                   mg.Movie.Link
               };
    var result = test.GroupBy(x => x.Name)
            .Select(x => new { Genre = x.Key, Matches = string.Join(", ", x.Select(y => y.Title)), Links = x.Select(z => z.Link).Distinct() })
            .Where(x => x.Genre == Name).ToListAsync();
    return await result;
});

//H�mta alla filmer som �r kopplade till en specifik person
app.MapGet("/api/Movies/{firstName}", async (DataContext context, string Name) =>
{
    var test = from r in context.Ratings
               select new
               {
                   r.Person.FirstName,
                   r.Movie.Title,
                   r.MovieRating
               };
    return await test.Where(x => x.FirstName == Name).ToListAsync();
});

// L�gga in och h�mta "rating" p� filmer kopplat till en person

// Koppla en person till en ny genre

// L�gga in nya l�nkar f�r en specifik person och en specifik genre

// F� f�rslag p� filmer i en viss genre fr�n ett externt API, t.ex TMDB. 

//Get Person by Name
//app.MapGet("/api/Persons/{firstName}", async (DataContext context, string firstName) =>
//    await context.Persons.FindAsync(firstName) is Person person ? Results.Ok(person) : Results.NotFound("Person not found ./"));

app.Run();