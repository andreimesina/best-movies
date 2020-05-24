using System;
using System.Collections.Generic;
using BestMovies.DTOs;
using BestMovies.Models;
using BestMovies.Repositories.GenreRepository;
using Microsoft.AspNetCore.Mvc;

namespace BestMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public IGenreRepository IGenreRepository { get; set; }

        public GenreController(IGenreRepository repository)
        {
            IGenreRepository = repository;
        }

        // GET: api/Genre
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> Get()
        {
            return IGenreRepository.GetAll();
        }

        // GET: api/Genre/5
        [HttpGet("{id}")]
        public ActionResult<Genre> Get(int id)
        {
            return IGenreRepository.Get(id);
        }

        // POST: api/Genre
        [HttpPost]
        public Genre Post(GenreDTO value)
        {
            Genre model = new Genre()
            {
                Name = value.Name

            };

            return IGenreRepository.Create(model);
        }

        // PUT: api/Genre/5
        [HttpPut("{id}")]
        public Genre Put(int id, GenreDTO value)
        {
            Genre model = IGenreRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }

            return IGenreRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Genre Delete(int id)
        {
            Genre model = IGenreRepository.Get(id);
            return IGenreRepository.Delete(model);
        }
    }
}
