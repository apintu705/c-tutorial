using MovieApp.Domain;
using MovieApp.Repository;
using MovieApp.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieApp.Services
{
    public class MovieService : IMovieService
    {
        
        public string AddMovie(string movieName, string moviePlot, string yearOfRelease, string selectedActors, string selectedProducer)
        {
            if(string.IsNullOrEmpty(movieName) || string.IsNullOrEmpty(moviePlot) || string.IsNullOrEmpty(yearOfRelease)
                || string.IsNullOrEmpty(selectedActors) || string.IsNullOrEmpty(selectedProducer))
            {
                Utils.Utils.PrintMessage("input should not be empty", false);
                return "failed Invalid inputs";
            }
            if(yearOfRelease.Length != 4)
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
                    Utils.Utils.PrintMessage("invalid year of release please enter valid details",false);
                    Thread.Sleep(2000);
                    return "failed Invalid inputs";
                }
            }

            string[] actorsIndex = selectedActors.Split(' ');
            string[] producerIndex = selectedProducer.Split(' ');
            var avaliableProducers = new ProducerService().GetProducers();
            var avaliableActors = new ActorService().GetActors();   

            var actors = new List<Actor>();
            for(int i=0; i<actorsIndex.Count(); i++)
            {
                if (int.Parse(actorsIndex[i]) < 1 || int.Parse(actorsIndex[i]) > avaliableActors.Count)
                {
                    Utils.Utils.PrintMessage("you have selected invalid actor from the list please restart the process", false);
                    Thread.Sleep(1000);
                    return "invalid";
                }
                actors.Add(avaliableActors[int.Parse(actorsIndex[i])-1]);
            }
            var producer = new List<Producer>();
            for (int i = 0; i < producerIndex.Count(); i++)
            {
                if (int.Parse(producerIndex[i]) < 1 || int.Parse(producerIndex[i]) > avaliableProducers.Count)
                {
                    Utils.Utils.PrintMessage("you have selected invalid actor from the list please restart the process", false);
                    Thread.Sleep(1000);
                    return "invalid";
                }
                producer.Add(avaliableProducers[int.Parse(producerIndex[i])-1]);
            }

            MovieRepository.SetMovieToList(new Domain.Movie(movieName, moviePlot, int.Parse(yearOfRelease), actors, producer));
            return "successfully added";
        }

        public List<Movie> GetMovies()
        {
            return MovieRepository.GetMoviesFromList();

        }

        public void DeleteMovie(int Index)
        {
            var movies = MovieRepository.GetMoviesFromList();

            if(movies.Count <= 0 || Index > movies.Count -1)
            {
                Utils.Utils.PrintMessage("please Enter valid index to delete movie",false);
                return;
            }
            MovieRepository.DeleteMovieFromList(Index);
        }
    }
}
