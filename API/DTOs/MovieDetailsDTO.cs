using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestMovies.DTOs
{
    public class MovieDetailsDTO
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public int Vote { get; set; }

        public List<string> ActorName { get; set; }
        public List<string> GenreName { get; set; }
        public List<string> CompanyName { get; set; }
    }
}
