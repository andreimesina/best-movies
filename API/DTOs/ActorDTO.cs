using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestMovies.Models;

namespace BestMovies.DTOs
{
    public class ActorDTO
    {
        public string Name { get; set; }

        public List<int> MovieId { get; set; }
    }
}
