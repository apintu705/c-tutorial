using Domain;
using MovieApp.Service.Interfaces;
using Repository.Interfaces;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service
{
    public class MovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IActorService _actorService;
        private readonly IProducerService _producerService;
        public MovieService(ProducerService producerService, ActorService actorService)
        {
            _movieRepository = new MovieRepository();
            _actorService = actorService;
            _producerService = producerService;
        }

        public string AddMovie(string movieName, string moviePlot, string yearOfRelease, string selectedActors, string selectedProducer)
        {
            if (string.IsNullOrEmpty(movieName) || string.IsNullOrEmpty(moviePlot) || string.IsNullOrEmpty(yearOfRelease)
                || string.IsNullOrEmpty(selectedActors) || string.IsNullOrEmpty(selectedProducer))
            {
                Utils.Utils.PrintMessage("input should not be empty", false);
                return "failed Invalid inputs";
            }
            if (yearOfRelease.Length != 4)
            {
                Utils.Utils.PrintMessage("invalid year of release please enter valid details", false);
                Thread.Sleep(2000);
                return "failed Invalid inputs";
            }
            else
            {
                try
                {
                    int.Parse(yearOfRelease);
                }
                catch
                {
                    Utils.Utils.PrintMessage("invalid year of release please enter valid details", false);
                    Thread.Sleep(2000);
                    return "failed Invalid inputs";
                }
            }

            string[] actorsIndex = selectedActors.Split(' ');
            string[] producerIndex = selectedProducer.Split(' ');
            var avaliableProducers = _producerService.GetProducers();
            var avaliableActors = _actorService.GetActors();

            var actors = new List<Actor>();
            for (int i = 0; i < actorsIndex.Count(); i++)
            {
                try 
                {
                    var disiredActor = avaliableActors.Where((actor) => actor.Id == int.Parse(actorsIndex[i]));
                    actors.Add(disiredActor.ToArray()[0]);
                }
                catch
                {
                    Utils.Utils.PrintMessage("you have entered invalid actor Id from the list please restart the process", false);
                    Thread.Sleep(2000);
                    return "invalid";
                }
            }
            var producers = new List<Producer>();
            for (int i = 0; i < producerIndex.Count(); i++)
            {
                try
                {
                    var disiredProducer = avaliableProducers.Where((producer) => producer.Id == int.Parse(producerIndex[i]));
                    producers.Add(disiredProducer.ToArray()[0]);
                }
                catch
                {
                    Utils.Utils.PrintMessage("you have entered invalid producer Id from the list please restart the process", false);
                    Thread.Sleep(2000);
                    return "invalid";
                }
            }

            int id = _movieRepository.MovieId();

            _movieRepository.SetMovieToList(new Domain.Movie(id,movieName, moviePlot, int.Parse(yearOfRelease), actors, producers));
            return "successfully added";
        }

        public List<MovieOutput> GetMovies()
        {
            var movies = _movieRepository.GetMoviesFromList();
            
            var movieOutputs = movies.Select((movie) =>
            new MovieOutput(movie.Id, movie.Name, movie.Plot, movie.YearOfRelease,
            string.Join(",", movie.Actors.Select((actor) => actor.Name).ToArray()),
            string.Join(",", movie.Producers.Select((producer) => producer.Name).ToArray()))).ToList();
            
            return movieOutputs ;

        }

        public void DeleteMovie(int Index)
        {
            var movies = _movieRepository.GetMoviesFromList();
            var movie = movies.FirstOrDefault(x => x.Id == Index);
            if(movie == null)
            {
                Utils.Utils.PrintMessage("please enter the valid movie id", false);
                Thread.Sleep(2000);
                return;
            }
            _movieRepository.DeleteMovieFromList(Index);
        }
    }
}
