using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Movies
{
    public class Movies
    {
        public string MovieName { get; set; }
        public DateTime YearOfRelease { get; set; }
        public string Plot { get; set; }
        public string Actors { get; set; }

        public string Producer { get; set; }

        public Movies(string movieName, DateTime yearOfRelease, string plot, string actors, string producer)
        {
            MovieName = movieName;
            YearOfRelease = yearOfRelease;
            Plot = plot;
            Actors = actors;
            Producer = producer;
        }
    }
}
