using BddAssignment3.Repository;
using BddAssignment3.Servie;
using BddAssignment3.utility;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddAssignment3.UserInterface
{
    public class MovieDisplay
    {
        private readonly MovieService movieService = new MovieService();

        public void DisplayAllMovies()
        {
            var movies = movieService.GetMovieList();
            if(movies.Count <= 0)
            {
                Utility.PrintMessage("No movies in the list", true);
            }
            else
            {
                var table = new ConsoleTable("Id", "MovieName", "MoviePlot", "Release Date", "Actors", "Producer");
                foreach(var movie in movies)
                {
                    table.AddRow(movie.Id, movie.MovieName, movie.MoviePlot, movie.ReleaseDate, movie.Actors, movie.Producer);
                }
                table.Write();
            }
        }
    }
}
