using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BestMovies.DTOs;
using BestMovies.Models;
using BestMovies.Repositories.MovieActorRepository;

namespace BestMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorController : ControllerBase
    {
        public IMovieActorRepository IMovieActorRepository { get; set; }

        public MovieActorController(IMovieActorRepository repository)
        {
            IMovieActorRepository = repository;
        }

        // GET: api/MovieActor
        [HttpGet]
        public ActionResult<IEnumerable<MovieActor>> Get()
        {
            return IMovieActorRepository.GetAll();
        }

        // GET: api/MovieActor/5
        [HttpGet("{id}")]
        public ActionResult<MovieActor> Get(int id)
        {
            return IMovieActorRepository.Get(id);
        }

        // POST: api/MovieActor
        [HttpPost]
        public MovieActor Post(MovieActorDTO value)
        {
            MovieActor model = new MovieActor()
            {
                MovieId = value.MovieId,
                ActorId = value.ActorId,
                CharacterName = value.CharacterName,
            };
            return IMovieActorRepository.Create(model);
        }

        // PUT: api/MovieActor/5
        [HttpPut("{id}")]
        public MovieActor Put(int id, MovieActorDTO value)
        {
            MovieActor model = IMovieActorRepository.Get(id);
            if (value.MovieId != 0)
            {
                model.MovieId = value.MovieId;
            }

            if (value.ActorId != 0)
            {
                model.ActorId = value.ActorId;
            }

            if (value.CharacterName != null)
            {
                model.CharacterName = value.CharacterName;
            }

            return IMovieActorRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public MovieActor Delete(int id)
        {
            MovieActor model = IMovieActorRepository.Get(id);
            return IMovieActorRepository.Delete(model);
        }
    }
}
