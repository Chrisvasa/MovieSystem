using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<PersonGenre> PersonGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonGenre>()
    .HasIndex(pg => new { pg.PersonId, pg.GenreId })
    .IsUnique();
            modelBuilder.Entity<MovieGenre>()
                .HasIndex(mg => new { mg.MovieId, mg.GenreId })
                .IsUnique();
            modelBuilder.Entity<Movie>()
                .HasIndex(m => new { m.Link })
                .IsUnique();
            modelBuilder.Entity<PersonGenre>()
                .HasIndex(pg => new { pg.PersonId, pg.GenreId })
                .IsUnique();
            modelBuilder.Entity<Genre>()
                .HasIndex(g => new { g.Name })
                .IsUnique();
            modelBuilder.Entity<Person>()
                .HasIndex(p => new { p.Email })
                .IsUnique();
            modelBuilder.Entity<Rating>()
                .HasIndex(r => new { r.PersonId, r.MovieId })
                .IsUnique();

            modelBuilder.Entity<Genre>().HasData(new Genre[] {
                new Genre{Id=28,Name="Action", Description="Big BOOM"},
                new Genre{Id=12,Name="Adventure", Description="Big ADVENTURE"},
                new Genre{Id=16,Name="Animation", Description="Big COMPUTERGRAPHIC"},
                new Genre{Id=35,Name="Comedy", Description="Big LAUGH"},
                new Genre{Id=80,Name="Crime", Description="Big POLICE CHASE"},
                new Genre{Id=99,Name="Documentary", Description="Big REAL LIFE MOVIE"},
                new Genre{Id=18,Name="Drama", Description="Big ARGUMENT"},
                new Genre{Id=10751,Name="Family", Description="Vin Diesel"},
                new Genre{Id=14,Name="Fantasy", Description="Big NERD"},
                new Genre{Id=36,Name="History", Description="Big OLD MAN STORY"},
                new Genre{Id=27,Name="Horror", Description="Big SCARE"},
                new Genre{Id=10402,Name="Music", Description="Big UNTZ UNTZ"},
                new Genre{Id=9648,Name="Mystery", Description="Big HMM"},
                new Genre{Id=10749,Name="Romance", Description="Big LOVE STORY"},
                new Genre{Id=878,Name="Science Fiction", Description="Big SMARTS"},
                new Genre{Id=10770,Name="TV Movie", Description="Big MOVIE"},
                new Genre{Id=53,Name="Thriller", Description="Big MICHAEL JACKSON"},
                new Genre{Id=10752,Name="War", Description="Big PANG PANG"},
                new Genre{Id=37,Name="Western", Description="Big YEHAAAW"}
            });
            modelBuilder.Entity<Person>().HasData(new Person[]
            {
                new Person{Id = 1, FirstName="Fibbe", LastName="Biffkatt", Email="Fibbe@biffkatt.se"},
                new Person{Id = 2, FirstName="Hank", LastName="Hill", Email="Hank@hill.usa"},
                new Person{Id = 3, FirstName="Bob", LastName="Mcbobson", Email="Bob@mail.com"},
                new Person{Id = 4, FirstName="Ferdinand", LastName="Tjurskalle", Email="Tjurskalle@mail.com"},
                new Person{Id = 5, FirstName="Billy", LastName="Willy", Email="Billy@mail.com"},
                new Person{Id = 6, FirstName="Roger", LastName="Pontare", Email="Roger@mail.com"}
            });
            modelBuilder.Entity<Movie>().HasData(new Movie[]
            {
                new Movie{Id = 1, Title="Die Hard", Link="https://www.themoviedb.org/movie/562-die-hard", PersonId=1},
                new Movie{Id = 2, Title="John Wick", Link="https://www.themoviedb.org/movie/245891-john-wick", PersonId=1},
                new Movie{Id = 3, Title="John Wick: Chapter 2", Link="https://www.themoviedb.org/movie/324552-john-wick-chapter-2", PersonId=3},
                new Movie{Id = 4, Title="The Super Mario Bros. Movie", Link="https://www.themoviedb.org/movie/502356-the-super-mario-bros-movie", PersonId=4}
            });
            modelBuilder.Entity<MovieGenre>().HasData(new MovieGenre[]
            {
                new MovieGenre{Id = 1, MovieId=1,GenreId=28},
                new MovieGenre{Id = 2, MovieId=1,GenreId=35},
                new MovieGenre{Id = 3, MovieId=2,GenreId=28},
                new MovieGenre{Id = 4, MovieId=2,GenreId=53},
                new MovieGenre{Id = 5, MovieId=3,GenreId=28},
                new MovieGenre{Id = 6, MovieId=3,GenreId=80},
                new MovieGenre{Id = 7, MovieId=3,GenreId=53},
                new MovieGenre{Id = 8, MovieId=4,GenreId=16},
                new MovieGenre{Id = 9, MovieId=4,GenreId=12},
                new MovieGenre{Id = 10, MovieId=4,GenreId=10751},
                new MovieGenre{Id = 11, MovieId=4,GenreId=14},
                new MovieGenre{Id = 12, MovieId=4,GenreId=35}
            });
            modelBuilder.Entity<PersonGenre>().HasData(new PersonGenre[]
            {
                new PersonGenre{Id = 1, PersonId=1,GenreId=28},
                new PersonGenre{Id = 2, PersonId=1,GenreId=35},
                new PersonGenre{Id = 3, PersonId=1,GenreId=80},
                new PersonGenre{Id = 4, PersonId=2,GenreId=28},
                new PersonGenre{Id = 5, PersonId=2,GenreId=35},
                new PersonGenre{Id = 6, PersonId=3,GenreId=12},
                new PersonGenre{Id = 7, PersonId=3,GenreId=10751},
                new PersonGenre{Id = 8, PersonId=4,GenreId=18},
                new PersonGenre{Id = 9, PersonId=4,GenreId=878}
            });
        }
    }
}
