using System;
using System.Collections.Generic;
using BestMovies.Models;

namespace BestMovies.Repositories.MovieGenreRepository
{
    public interface IMovieGenreRepository
    {
        List<MovieGenre> GetAll();
        MovieGenre Get(int Id);
        MovieGenre Create(MovieGenre MovieGenre);
        MovieGenre Update(MovieGenre MovieGenre);
        MovieGenre Delete(MovieGenre MovieGenre);
    }
}
