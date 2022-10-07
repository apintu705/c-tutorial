using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddAssignment3.movie.Interfaces
{
    public interface IAddMovie
    {
        string AddMovie(string movieName, string moviePlot, DateTime releaseDate, string actor, string producer);
        List<MovieModel> GetMovieList();
    }
}
