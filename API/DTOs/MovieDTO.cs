using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestMovies.DTOs
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public int RunTime { get; set; }
        public int Vote { get; set; }

        public List<int> ActorId { get; set; }
        public List<int> GenreId { get; set; }
        public List<int> CompanyId { get; set; }
    }
}
