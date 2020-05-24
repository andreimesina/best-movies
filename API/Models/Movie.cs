using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public int Vote { get; set; }

        public List<MovieActor> MovieActor { get; set; }
        public List<MovieCompany> MovieCompany { get; set; }
        public List<MovieGenre> MovieGenre { get; set; }
    }
}
