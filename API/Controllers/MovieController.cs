using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BestMovies.DTOs;
using BestMovies.Models;
using BestMovies.Repositories.MovieRepository;
using BestMovies.Repositories.MovieActorRepository;
using BestMovies.Repositories.MovieGenreRepository;
using BestMovies.Repositories.MovieCompanyRepository;
using BestMovies.Repositories.ActorRepository;
using BestMovies.Repositories.GenreRepository;
using BestMovies.Repositories.CompanyRepository;

namespace BestMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public IMovieRepository IMovieRepository { get; set; }
        public IMovieActorRepository IMovieActorRepository { get; set; }
        public IMovieCompanyRepository IMovieCompanyRepository { get; set; }
        public IMovieGenreRepository IMovieGenreRepository { get; set; }
        public IActorRepository IActorRepository { get; set; }
        public ICompanyRepository ICompanyRepository { get; set; }
        public IGenreRepository IGenreRepository { get; set; }


        public MovieController(IMovieRepository movieRepository, IActorRepository actorRepository, ICompanyRepository companyRepository, IGenreRepository genreRepository, IMovieActorRepository movieActorRepository, IMovieCompanyRepository movieCompanyRepository, IMovieGenreRepository movieGenreRepository)
        {
            IMovieRepository = movieRepository;
            IActorRepository = actorRepository;
            ICompanyRepository = companyRepository;
            IGenreRepository = genreRepository;
            IMovieActorRepository = movieActorRepository;
            IMovieCompanyRepository = movieCompanyRepository;
            IMovieGenreRepository = movieGenreRepository;
        }

        // GET: api/Movies
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            return IMovieRepository.GetAll();
        }

        // GET: api/Movie/5
        [HttpGet("{id}")]
        public MovieDetailsDTO Get(int id)
        {
            Movie Movie = IMovieRepository.Get(id);
            MovieDetailsDTO MyMovie = new MovieDetailsDTO()
            {
                Title = Movie.Title,
                ReleaseDate = Movie.ReleaseDate,
                RunTime = Movie.RunTime,
                Vote = Movie.Vote
            };
            IEnumerable<MovieActor> MyMovieActors = IMovieActorRepository.GetAll().Where(x => x.MovieId == Movie.Id);
            if (MyMovieActors != null)
            {
                List<string> MovieActorList = new List<string>();
                foreach (MovieActor MyMovieActor in MyMovieActors)
                {
                    Actor MyActor = IActorRepository.GetAll().SingleOrDefault(x => x.Id == MyMovieActor.ActorId);
                    MovieActorList.Add(MyActor.Name);
                }
                MyMovie.ActorName = MovieActorList;
            }
            IEnumerable<MovieCompany> MyMovieCompanies = IMovieCompanyRepository.GetAll().Where(x => x.MovieId == Movie.Id);
            if (MyMovieCompanies != null)
            {
                List<string> MovieCompanyList = new List<string>();
                foreach (MovieCompany MyMovieCompany in MyMovieCompanies)
                {
                    Company MyCompany = ICompanyRepository.GetAll().SingleOrDefault(x => x.Id == MyMovieCompany.CompanyId);
                    MovieCompanyList.Add(MyCompany.Name);
                }
                MyMovie.CompanyName = MovieCompanyList;
            }
            IEnumerable<MovieGenre> MyMovieGenres = IMovieGenreRepository.GetAll().Where(x => x.MovieId == Movie.Id);
            if (MyMovieGenres != null)
            {
                List<string> MovieGenreList = new List<string>();
                foreach (MovieGenre MyMovieGenre in MyMovieGenres)
                {
                    Genre MyGenre = IGenreRepository.GetAll().SingleOrDefault(x => x.Id == MyMovieGenre.GenreId);
                    MovieGenreList.Add(MyGenre.Name);
                }
                MyMovie.GenreName = MovieGenreList;
            }
            return MyMovie;
        }

        // POST: api/Movie
        [HttpPost]
        public void Post(MovieDTO value)
        {
            Movie model = new Movie()
            {
                Title = value.Title,
                ReleaseDate = value.ReleaseDate,
                RunTime = value.RunTime,
                Vote = value.Vote
            };
            IMovieRepository.Create(model);
            for (int i = 0; i < value.ActorId.Count; i++)
            {
                MovieActor MovieActor = new MovieActor()
                {
                    MovieId = model.Id,
                    ActorId = value.ActorId[i]
                };
                IMovieActorRepository.Create(MovieActor);
            }
            for (int i = 0; i < value.CompanyId.Count; i++)
            {
                MovieCompany MovieCompany = new MovieCompany()
                {
                    MovieId = model.Id,
                    CompanyId = value.CompanyId[i]
                };
                IMovieCompanyRepository.Create(MovieCompany);
            }
            for (int i = 0; i < value.GenreId.Count; i++)
            {
                MovieGenre MovieGenre = new MovieGenre()
                {
                    MovieId = model.Id,
                    GenreId = value.GenreId[i]
                };
                IMovieGenreRepository.Create(MovieGenre);
            }

        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, MovieDTO value)
        {
            Movie model = IMovieRepository.Get(id);
            if (value.Title != null)
            {
                model.Title = value.Title;
            }
            if (value.ReleaseDate != null)
            {
                model.ReleaseDate = value.ReleaseDate;
            }
            if (value.RunTime != 0)
            {
                model.RunTime = value.RunTime;
            }
            if (value.Vote != 0)
            {
                model.Vote = value.Vote;
            }
            IMovieRepository.Update(model);

            if (value.ActorId != null)
            {
                IEnumerable<MovieActor> MyMovieActors = IMovieActorRepository.GetAll().Where(x => x.MovieId == id);
                foreach (MovieActor MyMovieActor in MyMovieActors)
                    IMovieActorRepository.Delete(MyMovieActor);
                for (int i = 0; i < value.ActorId.Count; i++)
                {
                    MovieActor MovieActor = new MovieActor()
                    {
                        MovieId = model.Id,
                        ActorId = value.ActorId[i]
                    };
                    IMovieActorRepository.Create(MovieActor);
                }
            }
            if (value.CompanyId != null)
            {
                IEnumerable<MovieCompany> MyMovieCompanies = IMovieCompanyRepository.GetAll().Where(x => x.MovieId == id);
                foreach (MovieCompany MyMovieCompany in MyMovieCompanies)
                    IMovieCompanyRepository.Delete(MyMovieCompany);
                for (int i = 0; i < value.CompanyId.Count; i++)
                {
                    MovieCompany MovieCompany = new MovieCompany()
                    {
                        MovieId = model.Id,
                        CompanyId = value.CompanyId[i]
                    };
                    IMovieCompanyRepository.Create(MovieCompany);
                }
            }
            if (value.GenreId != null)
            {
                IEnumerable<MovieGenre> MyMovieGenres = IMovieGenreRepository.GetAll().Where(x => x.MovieId == id);
                foreach (MovieGenre MyMovieGenre in MyMovieGenres)
                    IMovieGenreRepository.Delete(MyMovieGenre);
                for (int i = 0; i < value.GenreId.Count; i++)
                {
                    MovieGenre MovieGenre = new MovieGenre()
                    {
                        MovieId = model.Id,
                        GenreId = value.GenreId[i]
                    };
                    IMovieGenreRepository.Create(MovieGenre);
                }
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Movie Delete(int id)
        {
            Movie movie = IMovieRepository.Get(id);
            return IMovieRepository.Delete(movie);
        }
    }
}
