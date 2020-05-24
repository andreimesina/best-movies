using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestMovies.Models;
using BestMovies.Contexts;

namespace BestMovies.Repositories.MovieRepository
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie Get(int Id);
        Movie Create(Movie movie);
        Movie Update(Movie movie);
        Movie Delete(Movie movie);


    }
}
