using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestMovies.Contexts;
using BestMovies.Models;

namespace BestMovies.Repositories.ActorRepository
{
    public class ActorRepository : IActorRepository
    {
        public Context context { get; set; }

        public ActorRepository(Context context)
        {
            this.context = context;
        }

        public Actor Create(Actor Actor)
        {
            var result = context.Add<Actor>(Actor);
            context.SaveChanges();
            return result.Entity;
        }

        public Actor Delete(Actor Actor)
        {
            var result = context.Remove(Actor);
            context.SaveChanges();
            return result.Entity;
        }

        public Actor Get(int Id)
        {
            return context.Actors.SingleOrDefault(x => x.Id == Id);
        }

        public List<Actor> GetAll()
        {
            return context.Actors.ToList();
        }

        public Actor Update(Actor Actor)
        {
            context.Entry(Actor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Actor;
        }
    }
}
