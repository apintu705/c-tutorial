using Assignment3.Interfaces;
using System;
using ConsoleTables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Enums;

namespace Assignment3.Movies
{
    public class Imbd : IMovies
    {
        private readonly List<Movies> _movieList = new List<Movies>();

        public void AddMovies()
        {
            Console.Clear();
            var name = InputValidator.Convert<string>("Enter movie Name");
            var yearOfRelease = InputValidator.Convert<DateTime>("Enter Date of release");
            var plot = InputValidator.Convert<string>("Enter movie Plot");
            var actor = Actors.SelectActors() ;
            var producer = Actors.SelectProducer();
            
            _movieList.Add(new Movies(name, yearOfRelease, plot, actor, producer));
            

        }
        public void GetMovies()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to Get all the movies");
                Console.WriteLine("Enter 2 to Get the list all movies released after year 2010");
                Console.WriteLine("Enter 3 to Get the name of all movies ");
                Console.WriteLine("Enter 4 to Get the name and year of release of all movies");
                Console.WriteLine("Enter 5 to Get the latest movie whose name contains ‘Avatar’");
                Console.WriteLine("Enter 6 to Get the list of all those movies in which the actor ’Will Smith’ has acted");
                Console.WriteLine("Enter 0 to Return main menu");


                switch (InputValidator.Convert<int>("Enter an option: "))
                {
                    case (int)GettingMovies.getAllMovies:
                        ListOfMovies();
                        break;

                    case (int)GettingMovies.getMovieReleasedafter:
                        AdvancedMethods.GetMovieReleasedafter(_movieList);
                        break;

                    case (int)GettingMovies.getNameOfallMovie:
                        AdvancedMethods.GetNameOfallMovie(_movieList);
                        break;

                    case (int)GettingMovies.getNameAndReleasedYearOfAllMovies:
                        AdvancedMethods.GetNameAndReleasedYearOfAllMovies(_movieList);
                        break;

                    case (int)GettingMovies.getMovieByNameAvatar:
                        AdvancedMethods.GetMovieByNameAvatar(_movieList);
                        break;

                    case (int)GettingMovies.getAllTheMovieWillSmithActed:
                        AdvancedMethods.GetAllTheMovieWillSmithActed(_movieList);
                        break;

                    case 0:
                        Utility.PrintDotAnimation();
                        return;

                    default:
                        Utility.PrintMessage("Please select a valid option", false);
                        break;
                }
            }
        }
        public void ListOfMovies()
        {
            if (_movieList.Count <= 0)
            {
                Utility.PrintMessage("You have no Movies yet", true);
            }
            else
            {
                var table = new ConsoleTable("Movie Name", "Year of release", "plot", "Actors", "Producer" );
                foreach (var movie in _movieList)
                {
                    table.AddRow(movie.MovieName,String.Format("{0:M/d/yyyy}", movie.YearOfRelease), movie.Plot,movie.Actors,movie.Producer);
                }
                table.Options.EnableCount = false;
                table.Write();
                Utility.PrintMessage($"You have {_movieList.Count} movies. ", true);

            }
        }

        
    }
}
