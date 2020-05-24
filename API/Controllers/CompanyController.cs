using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BestMovies.DTOs;
using BestMovies.Models;
using BestMovies.Repositories.CompanyRepository;

namespace BestMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public ICompanyRepository ICompanyRepository { get; set; }

        public CompanyController(ICompanyRepository repository)
        {
            ICompanyRepository = repository;
        }

        // GET: api/Company
        [HttpGet]
        public ActionResult<IEnumerable<Company>> Get()
        {
            return ICompanyRepository.GetAll();
        }

        // GET: api/Company/5
        [HttpGet("{id}")]
        public ActionResult<Company> Get(int id)
        {
            return ICompanyRepository.Get(id);
        }

        // POST: api/Company
        [HttpPost]
        public Company Post(CompanyDTO value)
        {
            Company model = new Company()
            {
                Name = value.Name
            };

            return ICompanyRepository.Create(model);
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public Company Put(int id, CompanyDTO value)
        {
            Company model = ICompanyRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }

            return ICompanyRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Company Delete(int id)
        {
            Company model = ICompanyRepository.Get(id);
            return ICompanyRepository.Delete(model);
        }
    }
}
