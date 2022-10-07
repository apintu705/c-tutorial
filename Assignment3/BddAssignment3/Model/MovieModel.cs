using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddAssignment3.movie
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string MoviePlot { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Actors { get; set; }
        public string Producer { get; set; }

        public MovieModel(int id, string movieName, string moviePlot, DateTime releaseDate, string actors, string producer)
        {
            Id = id;
            MovieName = movieName;
            MoviePlot = moviePlot;
            ReleaseDate = releaseDate;
            Actors = actors;
            Producer = producer;
        }
    }
}
