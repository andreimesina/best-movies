using System;
using System.Collections.Generic;
using BestMovies.DTOs;
using BestMovies.Models;
using BestMovies.Repositories.ActorRepository;
using Microsoft.AspNetCore.Mvc;

namespace BestMovies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        public IActorRepository IActorRepository { get; set; }

        public ActorController(IActorRepository repository)
        {
            IActorRepository = repository;
        }

        // GET: api/Actor
        [HttpGet]
        public ActionResult<IEnumerable<Actor>> Get()
        {
            return IActorRepository.GetAll();
        }

        // GET: api/Actor/5
        [HttpGet("{id}")]
        public ActionResult<Actor> Get(int id)
        {
            return IActorRepository.Get(id);
        }

        // POST: api/Actor
        [HttpPost]
        public Actor Post(ActorDTO value)
        {
            Actor model = new Actor()
            {
                Name = value.Name
            };

            return IActorRepository.Create(model);
        }

        // PUT: api/Actor/5
        [HttpPut("{id}")]
        public Actor Put(int id, ActorDTO value)
        {
            Actor model = IActorRepository.Get(id);
            if (value.Name != null)
            {
                model.Name = value.Name;
            }

            return IActorRepository.Update(model);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Actor Delete(int id)
        {
            Actor model = IActorRepository.Get(id);
            return IActorRepository.Delete(model);
        }
    }
}
