using System;
using Microsoft.EntityFrameworkCore;
using BestMovies.Models;

namespace BestMovies.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieCompany> MovieCompanies { get; set; }
        public DbSet<Company> Companies { get; set; }

        public static bool isMigration = true;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isMigration)
            {
                optionsBuilder.UseSqlServer(@"Server=.\;Database=BestMoviesDB;Trusted_Connection=True;");
            }
        }

        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
