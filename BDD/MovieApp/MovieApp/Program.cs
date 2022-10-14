using MovieApp.Service;
using MovieApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieApp
{
    public class Program
    {
        static void Main()
        {

            var actorService = new ActorService();
            var producerService = new ProducerService();
            var movieService = new MovieService(producerService, actorService);

            Utils.Utils.DisplayDashBoard();
            while (true)
            {
                var userInput = Utils.Utils.Convert<int>("\n\nPlease select an option");
                switch (userInput)
                {
                    case (int)Enums.MovieAppEnums.ListMovies:
                        var movies = movieService.GetMovies();
                        if (movies.Count <= 0)
                        {
                            Utils.Utils.PrintMessage("Ther are no movie in the list ", true);
                        }
                        foreach (var movie in movies)
                        {
                            Console.WriteLine($"\n\n{movie.Id}. {movie.Name} ({movie.YearOfRelease})");
                            Console.WriteLine($"Plot:- {movie.Plot}");
                            Console.Write($"Actors:- {movie.Actors}");
                            Console.Write($"\nProducers:- {movie.Producers}");
                        }
                        break;

                    case (int)Enums.MovieAppEnums.AddMovie:
                        var actors = actorService.GetActors();
                        var producers = producerService.GetProducers();
                        if (actors.Count <= 0 || producers.Count <=0)
                        {
                            Utils.Utils.PrintMessage("Please add actor and producer first", false);
                            Thread.Sleep(2000);
                            Console.Clear();
                            Utils.Utils.DisplayDashBoard();
                            break;
                        }

                        var movieName = Utils.Utils.Convert<string>("Enter Movie name");
                        var plot = Utils.Utils.Convert<string>("Enter Movie Plot");
                        var yearOfRelease = Utils.Utils.Convert<string>("Enter Release year of movie");

                        foreach(var actor in actors)
                        {
                            Console.Write($"{actor.Id} {actor.Name} ");
                        }
                        var selectedActors = Utils.Utils.Convert<string>("\nEnter selected actors Id seperated by space ");

                        foreach(var producer in producers)
                        {
                            Console.Write($"{producer.Id}. {producer.Name} ");
                        }
                        var selectedProducer = Utils.Utils.Convert<string>("\nEnter selected producer Id seperated by space");

                        movieService.AddMovie(movieName, plot, yearOfRelease, selectedActors, selectedProducer);
                        Console.Clear();
                        Utils.Utils.DisplayDashBoard();
                        break;

                    case (int)Enums.MovieAppEnums.AddActor:
                        var actorName = Utils.Utils.Convert<string>("Enter Actor name");
                        var actorDOB = Utils.Utils.Convert<DateTime>("Enter Actor's Date of Birth");
                        actorService.AddActor(actorName, actorDOB);
                        Console.Clear();
                        Utils.Utils.DisplayDashBoard();
                        break;

                    case (int)Enums.MovieAppEnums.AddProducer:
                        var producerName = Utils.Utils.Convert<string>("Enter producer name");
                        var producerDOB = Utils.Utils.Convert<DateTime>("Enter producer's Date of Birth");
                        producerService.AddProducer(producerName, producerDOB);
                        Console.Clear();
                        Utils.Utils.DisplayDashBoard();
                        break;

                    case (int)Enums.MovieAppEnums.DeleteMovie:
                        var index = Utils.Utils.Convert<int>("Enter the Id of the desired movie to delete");
                        movieService.DeleteMovie(index);
                        Console.Clear();
                        Utils.Utils.DisplayDashBoard();
                        break;

                    case (int)Enums.MovieAppEnums.Exit:
                        Console.Clear();
                        Utils.Utils.PrintMessage("Thank you for using this app", true);
                        Thread.Sleep(2000);
                        return;

                    default:
                        Utils.Utils.PrintMessage("Please enter a valid option", false);
                        Thread.Sleep(1000);
                        break;
                }
            }

        }
    }
}
