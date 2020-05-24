using System;
using System.Collections.Generic;
using BestMovies.Models;

namespace BestMovies.Repositories.CompanyRepository
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();
        Company Get(int Id);
        Company Create(Company Company);
        Company Update(Company Company);
        Company Delete(Company Company);
    }
}
