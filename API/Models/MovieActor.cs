using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestMovies.Models
{
    public class MovieActor
    {

        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public string CharacterName { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Actor Actors { get; set; }
    }
}
