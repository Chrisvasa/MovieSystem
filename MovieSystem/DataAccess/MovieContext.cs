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
    public class MovieContext : DbContext
    {
        //public DataAccess(DbContextOptions options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<PersonGenre> PersonGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-I45J7IO; Initial Catalog=MovieSystemDB;Integrated Security=true;TrustServerCertificate=True");
        }
    }
}
