using Microsoft.EntityFrameworkCore;
using MovieSystem.DataAccess;
using MovieSystem.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add this here
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

app.MapGet("/api/Movies/", async (DataContext context) =>
{
    var movies = context.Movies;
    var moviePerson = movies.Join(context.Persons, movie => movie.PersonId,
        per => per.Id, (movie, per) => new
        {
            movie.Name,
            movie.Link,
            movie.DateAdded,
            per.FirstName,
            per.LastName
        }).ToListAsync();
    return await moviePerson;
});
//Get Person by Name
//app.MapGet("/api/Persons/{firstName}", async (DataContext context, string firstName) =>
//    await context.Persons.FindAsync(firstName) is Person person ? Results.Ok(person) : Results.NotFound("Person not found ./"));

app.Run();