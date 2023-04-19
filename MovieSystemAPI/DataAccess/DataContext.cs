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
        }
    }
}
