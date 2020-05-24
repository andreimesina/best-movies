using System;
using System.Collections.Generic;
using System.Linq;
using BestMovies.Contexts;
using BestMovies.Models;

namespace BestMovies.Repositories.MovieGenreRepository
{
    public class MovieGenreRepository : IMovieGenreRepository
    {
        public Context context { get; set; }

        public MovieGenreRepository(Context context)
        {
            this.context = context;
        }

        public MovieGenre Create(MovieGenre MovieGenre)
        {
            var result = context.Add<MovieGenre>(MovieGenre);
            context.SaveChanges();
            return result.Entity;
        }

        public MovieGenre Delete(MovieGenre MovieGenre)
        {
            var result = context.Remove(MovieGenre);
            context.SaveChanges();
            return result.Entity;
        }

        public MovieGenre Get(int Id)
        {
            return context.MovieGenres.SingleOrDefault(x => x.Id == Id);
        }

        public List<MovieGenre> GetAll()
        {
            return context.MovieGenres.ToList();
        }

        public MovieGenre Update(MovieGenre MovieGenre)
        {
            context.Entry(MovieGenre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return MovieGenre;
        }
    }
}
