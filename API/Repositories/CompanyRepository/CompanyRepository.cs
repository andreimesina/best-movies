using System;
using System.Collections.Generic;
using System.Linq;
using BestMovies.Contexts;
using BestMovies.Models;

namespace BestMovies.Repositories.CompanyRepository
{
    public class CompanyRepository : ICompanyRepository
    {
        public Context context { get; set; }

        public CompanyRepository(Context context)
        {
            this.context = context;
        }

        public Company Create(Company Company)
        {
            var result = context.Add<Company>(Company);
            context.SaveChanges();
            return result.Entity;
        }

        public Company Delete(Company Company)
        {
            var result = context.Remove(Company);
            context.SaveChanges();
            return result.Entity;
        }

        public Company Get(int Id)
        {
            return context.Companies.SingleOrDefault(x => x.Id == Id);
        }

        public List<Company> GetAll()
        {
            return context.Companies.ToList();
        }

        public Company Update(Company Company)
        {
            context.Entry(Company).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return Company;
        }
    }
}
