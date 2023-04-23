  

# A C# Minimal API project

  

A simple project in C# involving Minimal API, Entity Framework and SSMS. Allows the user to access and add to different parts of the DB with the use of API calls.

  
  

## Features

  

- Interact with the database using API calls(requests).

- Get information about users, genres and movies.
- Connect users to new movies, genres.
- Add Movies to the database and discover movies to any given genre. ([Thanks to TheMovieDBs API](https://www.themoviedb.org/))

## API Requests and their returned Data

  
| API Requests | Return Data |
| ------------- | ------------- |
| /api/Persons/| Returns information about all the users in the Database (Id, Name and Email)|
| /api/Genres/FilterByPerson?Name={FirstName}| Returns all liked genres of a specified user |
| /api/Genres/FilterByGenre?Name={GenreName} | An API call that allows the user to get all matching movies to a given genre |
| /api/Movies/GetMoviesForPerson?Name={FirstName} | Get all movies that a user has added to the DB |
| /api/Ratings/GetRatingsForPerson?Name={FirstName} | Get all movies and their ratings that a user has given|
| /api/ratings/addrating?movieId={movieId}&movieRating={rating}&personId={personId}| Allows a person to add ratings to a movie |
| /api/Genre/AddPersonToGenre?personId={personId}&genreId={genreId}| Allows a person to like new genres |
| /api/Movies/Add?title={movieTitle}&link={movieURL}&genres={GenresSeparatedByCommas}&personId={personId}| Allows for addition of new movies and their specified genres to the DB|
| /api/Movies/Suggestions?genre={genreName}| Searches for new movies with the specified genre (Uses TheMovieDBs API)|
  
  

## Programs and Tools used

- Insomnia - To test and verify that the different API Requests work correctly.

- Minimal API and Swagger to both develop and further test so that everything works.

- Entity Framework to setup the database using Code-First and creating the different tables using Models.

  

**Code Structure:**

| Method Name | Method Description |
| ------------- | ------------- |
| Program.cs | This contains all the main logic that runs the API|
| Models Folder | Contains all the different models that are used to create and update the DB |
| DataContext.cs  | Contains all the DBSet<Models> used by the program and also contains the modelbuilders used in the creation of the DB |
| Migrations Folder | Holds the DB initialization, constraint creation and some Data to fill the database for easier testing |

  

## Reflections and other thoughts
Here I will give some thoughts about the different choices I made in the creation of this application. Starting with the database. I went with a code-first design since I wanted to get more practice with Entity Framework and I noticed early how smoothly it went. Both creating, changing and deleting changes became a lot easier with Entity Framework and I am happy that I chose to go down this path.
For the API, I went with Minimal API since I had never worked with APIs before and it seemed easier to grasp at first compared to MVC and controllers. For bigger projects I can see why people would choose the other option since the code can get cluttered easier but for smaller APIs such as this one, it seems to be a very good choice.
And this project was supposed to deal with Repository Patterns but since I went with the Entity Framework implementation, which already uses Repository Pattern for its usage of DbSet< T > it felt uncessesary to add even more complexity to the code. I felt that the code would get more complex and hard to follow for no real benefit. 

Overall, I am happy with the program and the progress made in a short amount of time, but I still have a lot to learn about the different uses of both Minimal API and MVC. I also got more practice with LINQ in the creation of this application and noticed a lot of potential and will be sure to practice more LINQ.

![TMDB](https://www.themoviedb.org/assets/2/v4/logos/v2/blue_short-8e7b30f73a4020692ccca9c88bafe5dcb6f8a62a4c6bc55cd9ba82bb2cd95f6c.svg)

