using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestMovies.Models;

namespace BestMovies.Repositories.MovieActorRepository
{
    public interface IMovieActorRepository
    {
        List<MovieActor> GetAll();
        MovieActor Get(int Id);
        MovieActor Create(MovieActor MovieActor);
        MovieActor Update(MovieActor MovieActor);
        MovieActor Delete(MovieActor MovieActor);
    }
}
