using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Domain
{
    public class Movie
    {
        public string MovieName { get; set; }
        public string MoviePlot { get; set; }
        public int YearOfRelease { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Producer> Producers { get; set; }
        public Movie(string movieName, string moviePlot, int yearOfRelease, List<Actor> actors, List<Producer> producers)
        {
            MovieName = movieName;
            MoviePlot = moviePlot;
            YearOfRelease = yearOfRelease;
            Actors = actors;
            Producers = producers;
        }
    }
}
