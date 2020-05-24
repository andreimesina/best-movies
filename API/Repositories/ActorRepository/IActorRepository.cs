using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestMovies.Models;

namespace BestMovies.Repositories.ActorRepository
{
    public interface IActorRepository
    {
        List<Actor> GetAll();
        Actor Get(int Id);
        Actor Create(Actor Actor);
        Actor Update(Actor Actor);
        Actor Delete(Actor Actor);
    }
}
