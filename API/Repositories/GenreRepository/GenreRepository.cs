using System;
using System.Collections.Generic;
using System.Linq;
using BestMovies.Contexts;
using BestMovies.Models;

namespace BestMovies.Repositories.GenreRepository
{
    public class GenreRepository : IGenreRepository
    {
        public Context context { get; set; }

        public GenreRepository(Context context)
        {
            this.context = context;
        }

        public Genre Create(Genre Genre)
        {
            var result = context.Add<Genre>(Genre);
            context.SaveChanges();
            return result.Entity;
        }

        public Genre Delete(Genre Genre)
        {
            var result = context.Remove(Genre);
            context.SaveChanges();
            return result.Entity;
        }

        public Genre Get(int Id)
        {
            return context.Genres.SingleOrDefault(x => x.Id == Id);
        }

        public List<Genre> GetAll()
        {
            return context.Genres.ToList();
        }

        public Genre Update(Genre Genre)
        {
            context.Entry(Genre).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Genre;
        }
    }

}
