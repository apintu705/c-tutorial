using MovieApp.Domain;
using MovieApp.Services;
using MovieApp.Services.Interfaces;
using MovieApp.Tests.Support;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MovieApp.Tests.StepDefinitions
{
    [Binding]
    public class MovieAppStepDefinitions
    {
        private readonly MovieService _movieService = new();
        private readonly ActorService _actorService = new();
        private readonly ProducerService _producerService = new();
        private string? _movieName, _moviePlot, _yearOfRelease, _actors, _producer;
        private dynamic? _result;
        private List<Movie> _movies = new();
        private readonly List<MovieSupport> _movieSupport = new();   

        [BeforeScenario("addMovie")]
        public void AddSampleActorsAndProducers()
        {
            _actorService.AddActor("Will Smith", DateTime.Parse("11/12/2018"));
            _actorService.AddActor("Vijay D", DateTime.Parse("12/23/2014"));
            _actorService.AddActor("Alisha", DateTime.Parse("12/27/2013"));
            _actorService.AddActor("Ananya P", DateTime.Parse("12/27/2013"));
            _actorService.AddActor("Salman", DateTime.Parse("12/27/2013"));
            _actorService.AddActor("Katrina", DateTime.Parse("12/27/2013"));

            _producerService.AddProducer("Disney", DateTime.Parse("11/11/2010"));
            _producerService.AddProducer("Dharma", DateTime.Parse("11/11/2010"));
            _producerService.AddProducer("Sanjay Dutt", DateTime.Parse("11/11/2010"));
            

        }

        [Given(@"I have to add a movie with the details as ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" and ""([^""]*)""")]
        public void GivenIHaveToAddAMovieWithTheDetailsAsAnd(string p0, string moviePlot, string yearOfRelease, string p3, string p4)
        {
            
            _movieName = p0.ToString();
            _moviePlot = moviePlot.ToString();
            _yearOfRelease = yearOfRelease.ToString();
            _actors = p3.ToString();
            _producer = p4.ToString();
        }


        [When(@"I add the movie to the MovieApp")]
        public void WhenIAddTheMovieToTheMovieApp()
        {
            _result = _movieService.AddMovie(_movieName, _moviePlot, _yearOfRelease, _actors, _producer);
        }

        [Then(@"display message ""([^""]*)"" on the screen")]
        public void ThenDisplayMessageOnTheScreen(string p0)
        {
            Assert.Equal(_result, p0);
        }

        [BeforeScenario("listMovies")]
        public void AddSampleActorsProducersAndMovies()
        {
            _movieService.AddMovie("Liger", "action", "2020", "2 4", "2");
            _movieService.AddMovie("Tiger", "romance", "2000", "5 6", "3");


        }
        [Given(@"I have a MovieApp of movies")]
        public static void GivenIHaveAMovieAppOfMovies()
        {
        }

        [When(@"I fetch all the movies with details")]
        public void WhenIFetchAllTheMoviesWithDetails()
        {
            _movies = _movieService.GetMovies();

            
            foreach(var movie in _movies)
            {
                var actorCompare = new List<string>();
                var ProducerCompare = new List<string>();
                foreach(var item in movie.Actors)
                {
                    actorCompare.Add(item.ActorName);
                }
                foreach(var item in movie.Producers)
                {
                    ProducerCompare.Add(item.ProducerName);
                }
                _movieSupport.Add(new MovieSupport(movie.MovieName, movie.MoviePlot, movie.YearOfRelease, String.Join(",", actorCompare), String.Join(",", ProducerCompare)));
            }

        }

        [Then(@"I should have the following movies")]
        public void ThenIShouldHaveTheFollowingMovies(Table table)
        {
            table.CompareToSet(_movieSupport);
        }
    }
}
