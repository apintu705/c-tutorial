using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Tests.Support
{
    public class MovieSupport
    {
        public string MovieName { get; set; }
        public string MoviePlot { get; set; }
        public int YearOfRelease { get; set; }
        public string Actors { get; set; }
        public string Producers { get; set; }

        public MovieSupport(string movieName, string moviePlot, int yearOfRelease, string actors, string producers)
        {
            MovieName = movieName;
            MoviePlot = moviePlot;
            YearOfRelease = yearOfRelease;
            Actors = actors;
            Producers = producers;
        }
    }
}
