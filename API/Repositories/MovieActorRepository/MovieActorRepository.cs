using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestMovies.Contexts;
using BestMovies.Models;

namespace BestMovies.Repositories.MovieActorRepository
{
    public class MovieActorRepository : IMovieActorRepository
    {
        public Context context { get; set; }

        public MovieActorRepository(Context context)
        {
            this.context = context;
        }

        public MovieActor Create(MovieActor MovieActor)
        {
            var result = context.Add<MovieActor>(MovieActor);
            context.SaveChanges();
            return result.Entity;
        }

        public MovieActor Delete(MovieActor MovieActor)
        {
            var result = context.Remove(MovieActor);
            context.SaveChanges();
            return result.Entity;
        }

        public MovieActor Get(int Id)
        {
            return context.MovieActors.SingleOrDefault(x => x.Id == Id);
        }

        public List<MovieActor> GetAll()
        {
            return context.MovieActors.ToList();
        }

        public MovieActor Update(MovieActor MovieActor)
        {
            context.Entry(MovieActor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return MovieActor;
        }
    }
}
