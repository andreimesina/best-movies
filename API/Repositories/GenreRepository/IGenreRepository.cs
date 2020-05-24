using System;
using System.Collections.Generic;
using BestMovies.Models;

namespace BestMovies.Repositories.GenreRepository
{
    public interface IGenreRepository
    {
        List<Genre> GetAll();
        Genre Get(int Id);
        Genre Create(Genre Genre);
        Genre Update(Genre Genre);
        Genre Delete(Genre Genre);
    }
}
