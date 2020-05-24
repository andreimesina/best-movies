using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestMovies.DTOs
{
    public class MovieActorDTO
    {
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public string CharacterName { get; set; }
    }
}
