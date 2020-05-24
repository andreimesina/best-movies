using System;
using System.Collections.Generic;

namespace BestMovies.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<MovieCompany> MovieCompany { get; set; }
    }
}
