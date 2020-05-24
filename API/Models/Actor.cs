﻿using System.Collections.Generic;

namespace BestMovies.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<MovieActor> MovieActors { get; set; }
    }
}
