using System;
using System.Collections.Generic;
using System.Linq;
using BestMovies.Contexts;
using BestMovies.Models;

namespace BestMovies.Repositories.MovieCompanyRepository
{
    public class MovieCompanyRepository : IMovieCompanyRepository
    {
        public Context context { get; set; }

        public MovieCompanyRepository(Context context)
        {
            this.context = context;
        }

        public MovieCompany Create(MovieCompany MovieCompany)
        {
            var result = context.Add<MovieCompany>(MovieCompany);
            context.SaveChanges();
            return result.Entity;
        }

        public MovieCompany Delete(MovieCompany MovieCompany)
        {
            var result = context.Remove(MovieCompany);
            context.SaveChanges();
            return result.Entity;
        }

        public MovieCompany Get(int Id)
        {
            return context.MovieCompanies.SingleOrDefault(x => x.Id == Id);
        }

        public List<MovieCompany> GetAll()
        {
            return context.MovieCompanies.ToList();
        }

        public MovieCompany Update(MovieCompany MovieCompany)
        {
            context.Entry(MovieCompany).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return MovieCompany;
        }
    }
}
