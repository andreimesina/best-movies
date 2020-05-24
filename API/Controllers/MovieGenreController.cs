using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BestMovies.DTOs;
using BestMovies.Models;
using BestMovies.Repositories.MovieGenreRepository;

namespace BestMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieGenreController : ControllerBase
    {
        public IMovieGenreRepository IMovieGenreRepository { get; set; }

        public MovieGenreController(IMovieGenreRepository repository)
        {
            IMovieGenreRepository = repository;
        }

        // GET: api/MovieGenre
        [HttpGet]
        public ActionResult<IEnumerable<MovieGenre>> Get()
        {
            return IMovieGenreRepository.GetAll();
        }

        // GET: api/MovieGenre/5
        [HttpGet("{id}")]
        public ActionResult<MovieGenre> Get(int id)
        {
            return IMovieGenreRepository.Get(id);
        }

        // POST: api/MovieGenre
        [HttpPost]
        public MovieGenre Post(MovieGenreDTO value)
        {
            MovieGenre model = new MovieGenre()
            {
                MovieId = value.MovieId,
                GenreId = value.GenreId
            };
            return IMovieGenreRepository.Create(model);
        }

        // PUT: api/MovieGenre/5
        [HttpPut("{id}")]
        public MovieGenre Put(int id, MovieGenreDTO value)
        {
            MovieGenre model = IMovieGenreRepository.Get(id);
            if (value.MovieId != 0)
            {
                model.MovieId = value.MovieId;
            }

            if (value.GenreId != 0)
            {
                model.GenreId = value.GenreId;
            }

            return IMovieGenreRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public MovieGenre Delete(int id)
        {
            MovieGenre model = IMovieGenreRepository.Get(id);
            return IMovieGenreRepository.Delete(model);
        }
    }
}
