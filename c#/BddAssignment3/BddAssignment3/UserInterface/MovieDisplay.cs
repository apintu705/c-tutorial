using BddAssignment3.movie;
using BddAssignment3.movie.Interfaces;
using BddAssignment3.Repository;
using BddAssignment3.Service.Enums;
using BddAssignment3.Service.Interfaces;
using BddAssignment3.Servie;
using BddAssignment3.utility;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BddAssignment3.UserInterface
{
    public class MovieDisplay
    {
        private readonly IMovieService _movieService;
        private readonly IImbdServices _imbdServices;


        public MovieDisplay(MovieService movieService)
        {
            _movieService = movieService;
            _imbdServices = new IMBDServices(movieService);
        }

        public void DisplayAllMovies()
        {
            var movies = _movieService.GetMovieList();
            if(movies.Count <= 0)
            {
                Utility.PrintMessage("No movies in the list", true);
                Thread.Sleep(1000);
                return;
            }
            else
            {
                var table = new ConsoleTable("Id", "MovieName", "MoviePlot", "Release Date", "Actors", "Producer");
                foreach(var movie in movies)
                {
                    table.AddRow(movie.Id, movie.MovieName, movie.MoviePlot, movie.ReleaseDate, movie.Actors, movie.Producer);
                }
                table.Options.EnableCount = false;
                table.Write();
            }
        }

        public void AdvancedMethods()
        {
            Console.Clear();
            Console.WriteLine(@"Enter 1 to Get all the movies
Enter 2 to Get the list all movies released after year 2010
Enter 3 to Get the name of all movies
Enter 4 to Get the name and year of release of all movies
Enter 5 to Get the latest movie whose name contains ‘Avatar’
Enter 6 to Get the list of all those movies in which the actor ’Will Smith’ has acted
Enter 0 to Return main menu");
            while (true)
            {
                var userInput = Utility.Convert<int>("Enter an option: ");
                switch (userInput)
                {
                    case (int)AdvancedMethodsOption.getAllMovies:
                        DisplayAllMovies();
                        break;

                    case (int)AdvancedMethodsOption.getMovieReleasedafter:
                        _imbdServices.GetMovieReleasedafter();
                        break;

                    case (int)AdvancedMethodsOption.getNameOfallMovie:
                        _imbdServices.GetNameOfallMovie();
                        break;

                    case (int)AdvancedMethodsOption.getNameAndReleasedYearOfAllMovies:
                        _imbdServices.GetNameAndReleasedYearOfAllMovies();
                        break;

                    case (int)AdvancedMethodsOption.getMovieByNameAvatar:
                        _imbdServices.GetMovieByNameAvatar();
                        break;

                    case (int)AdvancedMethodsOption.getAllTheMovieWillSmithActed:
                        _imbdServices.GetAllTheMovieWillSmithActed();
                        break;

                    case 0:
                        Console.Clear();
                        return;

                    default:
                        Utility.PrintMessage("Please select a valid option", false);
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }
}
