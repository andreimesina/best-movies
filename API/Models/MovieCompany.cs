using System;
namespace BestMovies.Models
{
    public class MovieCompany
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int CompanyId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Company Company { get; set; }
    }
}
