using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Services.Interfaces
{
    public interface IMovieService
    {
        string AddMovie(string movieName, string moviePlot, string yearOfRelease, string selectedActors, string selectedProducer);
        List<Movie> GetMovies();
    }
}
