using System;
using System.Collections.Generic;
using BestMovies.Models;

namespace BestMovies.DTOs
{
    public class CompanyDTO
    {
        public string Name { get; set; }

        public List<int> MovieId { get; set; }
    }
}
