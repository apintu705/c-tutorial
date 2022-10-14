using BddAssignment3.movie;
using BddAssignment3.movie.Enums;
using BddAssignment3.movie.Interfaces;
using BddAssignment3.Repository;
using BddAssignment3.Servie;
using BddAssignment3.UserInterface;
using BddAssignment3.utility;
using System;


namespace BddAssignment3
{
    internal class Program
    {
        static void Main()
        {
            var movieService = new MovieService();
            var movieInput = new MovieInput(movieService);
            var movieDisplay = new MovieDisplay(movieService);

            
            while (true)
            {
                Console.WriteLine(@"welcome to the app

please select the desired options
Enter 1. to add movie
Enter 2. To get the list of added movies
Enter 3. To emplement all the advanced methods asked in the assignment
Enter 4. To Exit");
                var userInput = Utility.Convert<int>("\n\nplease Enter the desired option");
                switch (userInput)
                {
                    case (int)Options.AddMovie:
                        movieInput.AddMovieDetails();
                        break;
                    case (int)Options.GetListOfMovies:
                        movieDisplay.DisplayAllMovies();
                        break;
                    case (int)Options.AdvancedMethodOption:
                        movieDisplay.AdvancedMethods();
                        break;
                    case (int)Options.Exit:
                        Console.Clear();
                        return;
                    default:
                        Utility.PrintMessage("You have not select the valid option", false);
                        break;
                }
            }
        }
    }
    
}
