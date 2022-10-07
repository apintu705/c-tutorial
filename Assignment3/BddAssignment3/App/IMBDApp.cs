using BddAssignment3.movie.Enums;
using BddAssignment3.UserInterface;
using BddAssignment3.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddAssignment3.movie
{
    public class IMBDApp
    {
        public void StartAssignment()
        {
            var movieInput = new MovieInput();
            var movieDisplay = new MovieDisplay();
            Console.WriteLine(@"welcome to the app

please select the desired options
Enter 1. to add movie
Enter 2. To get the list of added movies
Enter 3. to exit the application");

            while (true)
            {
                var userInput = Utility.Convert<int>("\n\nplease Enter the disired option");
                switch (userInput)
                {
                    case (int)Options.AddMovie:
                        movieInput.AddMovieDetails();
                        break;
                    case (int)Options.GetListOfMovies:
                        movieDisplay.DisplayAllMovies();
                        break;
                    case (int)Options.Exit:
                        Console.Clear();
                        return;
                    default:
                        Utility.PrintMessage("You have not select the desired option", false);
                        break;
                }
            }
        }
    }
}
