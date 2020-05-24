using System;
using System.Collections.Generic;
using BestMovies.Models;

namespace BestMovies.Repositories.MovieCompanyRepository
{
    public interface IMovieCompanyRepository
    {
        List<MovieCompany> GetAll();
        MovieCompany Get(int Id);
        MovieCompany Create(MovieCompany MovieCompany);
        MovieCompany Update(MovieCompany MovieCompany);
        MovieCompany Delete(MovieCompany MovieCompany);
    }
}
