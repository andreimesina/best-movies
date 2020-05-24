using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestMovies.Models
{
    public class MovieGenre
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Genre Genres { get; set; }
    }
}
