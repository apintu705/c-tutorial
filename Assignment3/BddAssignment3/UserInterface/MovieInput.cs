using BddAssignment3.movie.Interfaces;
using BddAssignment3.Servie;
using BddAssignment3.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddAssignment3.UserInterface
{
    public class MovieInput 
    {
        private readonly MovieService movieService = new MovieService();
        public void AddMovieDetails()
        {
            var name = Utility.Convert<string>("Enter the Movie Name");
            var plot = Utility.Convert<string>("Enter the movie Plot");
            var releaseDate = Utility.Convert<DateTime>("Enter the Release date of movie");
            var actor = Utility.Convert<string>("Enter the Movie actors");
            var producer = Utility.Convert<string>("Enter the Movie Producer");
            
            movieService.AddMovie(name, plot, releaseDate, actor, producer);
        }
    }
}
