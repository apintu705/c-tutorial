using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public int YearOfRelease { get; set; }
        public List<Actor> Actors { get; set; }
        public List<Producer> Producers { get; set; }
        public Movie(int id, string movieName, string moviePlot, int yearOfRelease, List<Actor> actors, List<Producer> producers)
        {
            Id = id;
            Name = movieName;
            Plot = moviePlot;
            YearOfRelease = yearOfRelease;
            Actors = actors;
            Producers = producers;
        }
    }
}
