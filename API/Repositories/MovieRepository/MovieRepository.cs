using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestMovies.Models;
using BestMovies.Contexts;

namespace BestMovies.Repositories.MovieRepository
{
    public class MovieRepository : IMovieRepository
    {
        public Context _context { get; set; }

        public MovieRepository(Context context)
        {
            _context = context;
        }

        public Movie Create(Movie movie)
        {
            var result = _context.Add<Movie>(movie);
            _context.SaveChanges();
            return result.Entity;
        }

        public Movie Get(int Id)
        {
            return _context.Movies.SingleOrDefault(x => x.Id == Id);
        }
        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }
        public Movie Update(Movie Movie)
        {
            _context.Entry(Movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return Movie;
        }
        public Movie Delete(Movie Movie)
        {
            var result = _context.Remove(Movie);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
