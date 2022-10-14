using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MovieOutput
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public int YearOfRelease { get; set; }
        public string Actors { get; set; }
        public string Producers { get; set; }

        public MovieOutput(int id, string movieName, string moviePlot, int yearOfRelease, string actors, string producers)
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
