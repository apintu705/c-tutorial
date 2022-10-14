using System;
using TechTalk.SpecFlow;
using MovieApp.Service.Interfaces;
using MovieApp.Service;
using Domain;
using TechTalk.SpecFlow.Assist;

namespace MovieApp.Test.StepDefinitions
{
    [Binding]
    public class MovieAppStepDefinitions
    {
        private readonly MovieService _movieService;
        private readonly IActorService _actorService;
        private readonly IProducerService _producerService;
        private List<MovieOutput> _displayItems;
        public MovieAppStepDefinitions(ProducerService producerService, ActorService actorService)
        {
            _actorService = actorService;
            _producerService = producerService;
            _movieService = new MovieService(producerService, actorService);
            _displayItems = new List<MovieOutput>();
        }
        
        private string? _Name, _Plot, _yearOfRelease, _actors, _producer;
        private dynamic? _result;


        [BeforeScenario("addMovie")]
        public void AddSampleActorsAndProducers()
        {
            _actorService.AddActor("Will Smith", DateTime.Parse("11/12/2018"));
            _actorService.AddActor("Vijay D", DateTime.Parse("12/23/2014"));
            _actorService.AddActor("Alisha", DateTime.Parse("12/27/2013"));
            _producerService.AddProducer("Disney", DateTime.Parse("11/11/2010"));
        }
        [Given(@"I have to add a movie with the details as ""([^""]*)"", ""([^""]*)"", ""([^""]*)"", ""([^""]*)"" and ""([^""]*)""")]
        public void GivenIHaveToAddAMovieWithTheDetailsAsAnd(string p0, string fantasy, string p2, string p3, string p4)
        {
            _Name = p0.ToString();
            _Plot = fantasy.ToString();
            _yearOfRelease = p2.ToString();
            _actors = p3.ToString();
            _producer = p4.ToString();
        }

        [When(@"I add the movie to the MovieApp")]
        public void WhenIAddTheMovieToTheMovieApp()
        {
            _result = _movieService.AddMovie(_Name, _Plot, _yearOfRelease, _actors, _producer);
        }

        [Then(@"display message ""([^""]*)"" on the screen")]
        public void ThenDisplayMessageOnTheScreen(string p0)
        {
            Assert.Equal(_result, p0);
        }


        [BeforeScenario("listMovies")]
        public void AddSampleActorsProducersAndMovies()
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

            _movieService.AddMovie("Avatar", "fantasy", "2010", "1 3", "1");
            _movieService.AddMovie("Liger", "action", "2020", "2 4", "2");
            _movieService.AddMovie("Tiger", "romance", "2000", "5 6", "3");
        }

        [Given(@"I have a MovieApp of movies")]
        public void GivenIHaveAMovieAppOfMovies()
        {
        }

        [When(@"I fetch all the movies with details")]
        public void WhenIFetchAllTheMoviesWithDetails()
        {
            _displayItems = _movieService.GetMovies();
        }

        [Then(@"I should have the following movies")]
        public void ThenIShouldHaveTheFollowingMovies(Table table)
        {
            table.CompareToSet(_displayItems);
        }
    }
}
