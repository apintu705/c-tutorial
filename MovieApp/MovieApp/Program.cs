using MovieApp.Domain;
using MovieApp.Services;
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
            var movieService = new MovieService();
            var actorService = new ActorService();
            var producerService = new ProducerService();


            Utils.Utils.DisplayDashBoard();
            while (true)
            {
                var userInput = Utils.Utils.Convert<int>("\n\nPlease select an option");
                switch (userInput)
                {
                    case (int)Enums.MovieAppEnums.ListMovies:
                        var movies = movieService.GetMovies();
                        if(movies.Count <= 0)
                        {
                            Utils.Utils.PrintMessage("Ther are no movie in the list ", true);
                        }
                        foreach (var movie in movies)
                        {
                            Console.WriteLine($"\n\n{movie.MovieName} ({movie.YearOfRelease})");
                            Console.WriteLine($"Plot - {movie.MoviePlot}");
                            Console.Write("Actors - ");
                            foreach(var actor in movie.Actors)
                            {
                                Console.Write($"{actor.ActorName}  ");
                            }
                            Console.Write("\nProducers - ");
                            foreach(var producer in movie.Producers)
                            {
                                Console.Write($"{producer.ProducerName}  ");
                            }
                        }
                        break;

                    case (int)Enums.MovieAppEnums.AddMovie:
                        var movieName = Utils.Utils.Convert<string>("Enter Movie name");
                        var plot = Utils.Utils.Convert<string>("Enter Movie Plot");
                        var yearOfRelease = Utils.Utils.Convert<string>("Enter Release year of movie");

                        var actors = actorService.GetActors();
                        if(actors.Count <= 0)
                        {
                            Utils.Utils.PrintMessage("You have no actors to select please update the actor list first", false);
                            Thread.Sleep(2000);
                            Console.Clear();
                            Utils.Utils.DisplayDashBoard();
                            break;
                        }
                        for(int i =0; i < actors.Count; i++)
                        {
                            Console.Write($"{i + 1}. {actors[i].ActorName} ");
                        }
                        var selectedActors = Utils.Utils.Convert<string>("\nEnter selected actors Id seperated by space ");

                        var producers = producerService.GetProducers();
                        if(producers.Count <= 0)
                        {
                            Utils.Utils.PrintMessage("You have no priducers to select please update the producer list first", false);
                            Thread.Sleep(2000);
                            Console.Clear();
                            Utils.Utils.DisplayDashBoard();
                            break;
                        }
                        for(int i =0; i < producers.Count; i++)
                        {
                            Console.Write($"{i + 1}. {producers[i].ProducerName} ");
                        }
                        var selectedProducer = Utils.Utils.Convert<string>("\nEnter selected producer Id seperated by space");

                        movieService.AddMovie(movieName,plot,yearOfRelease,selectedActors,selectedProducer);
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
                        var index = Utils.Utils.Convert<int>("Enter the index of the desired movie to delete");
                        movieService.DeleteMovie(index);
                        Console.Clear();
                        Utils.Utils.DisplayDashBoard();
                        break;

                    case (int)Enums.MovieAppEnums.Exit:
                        Console.Clear();
                        Utils.Utils.PrintMessage("Thank you for using this app",true);
                        Thread.Sleep(2000);
                        return;

                    default:
                        Utils.Utils.PrintMessage("Please enter a valid option",false);
                        Thread.Sleep(1000);
                        break;
                }
            }
            
        }
    }
}
