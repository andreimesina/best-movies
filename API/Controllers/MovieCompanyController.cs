using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BestMovies.DTOs;
using BestMovies.Models;
using BestMovies.Repositories.MovieCompanyRepository;

namespace BestMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCompanyController : ControllerBase
    {
        public IMovieCompanyRepository IMovieCompanyRepository { get; set; }

        public MovieCompanyController(IMovieCompanyRepository repository)
        {
            IMovieCompanyRepository = repository;
        }

        // GET: api/MovieCompany
        [HttpGet]
        public ActionResult<IEnumerable<MovieCompany>> Get()
        {
            return IMovieCompanyRepository.GetAll();
        }

        // GET: api/MovieCompany/5
        [HttpGet("{id}")]
        public ActionResult<MovieCompany> Get(int id)
        {
            return IMovieCompanyRepository.Get(id);
        }

        // POST: api/MovieCompany
        [HttpPost]
        public MovieCompany Post(MovieCompanyDTO value)
        {
            MovieCompany model = new MovieCompany()
            {
                MovieId = value.MovieId,
                CompanyId = value.CompanyId,
            };
            return IMovieCompanyRepository.Create(model);
        }

        // PUT: api/MovieCompany/5
        [HttpPut("{id}")]
        public MovieCompany Put(int id, MovieCompanyDTO value)
        {
            MovieCompany model = IMovieCompanyRepository.Get(id);
            if (value.MovieId != 0)
            {
                model.MovieId = value.MovieId;
            }

            if (value.CompanyId != 0)
            {
                model.CompanyId = value.CompanyId;
            }

            return IMovieCompanyRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public MovieCompany Delete(int id)
        {
            MovieCompany model = IMovieCompanyRepository.Get(id);
            return IMovieCompanyRepository.Delete(model);
        }
    }
}
