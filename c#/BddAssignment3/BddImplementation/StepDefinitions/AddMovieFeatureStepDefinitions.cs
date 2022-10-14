using BddAssignment3.movie;
using BddAssignment3.Servie;
using System;
using System.Numerics;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using static System.Collections.Specialized.BitVector32;

namespace BddImplementation.StepDefinitions
{
    [Binding]
    public class AddMovieFeatureStepDefinitions
    {
        private readonly MovieService _movieService = new();

        private dynamic? _result;
        private string? _movieName;
        private string? _moviePlot;
        private DateTime _releaseDate;
        private string? _actor;
        private string? _producer;
        private List<MovieModel>? _movies;

        //add movie to the list

        [Given(@"I have an application which stores movies with it's details")]
        public static void GivenIHaveAnApplicationWhichStoresMoviesWithItsDetails()
        {
            
        }

        [Given(@"I entered MovieName as '([^']*)'")]
        public void GivenIEnteredMovieNameAs(string bahubali)
        {
            _movieName = bahubali;
        }

        [Given(@"I entered MoviePlot as '([^']*)'")]
        public void GivenIEnteredMoviePlotAs(string action)
        {
            _moviePlot = action;
        }

        [Given(@"I entered ReleaseDate as '([^']*)'")]
        public void GivenIEnteredReleaseDateAs(string p0)
        {
            _releaseDate = DateTime.Parse(p0);
        }

        [Given(@"I entered Actors as '([^']*)'")]
        public void GivenIEnteredActorsAs(string salman)
        {
            _actor = salman;
        }

        [Given(@"I entered Producer as '([^']*)'")]
        public void GivenIEnteredProducerAs(string disney)
        {
            _producer = disney;
        }

        [When(@"I entered all the details correctly i should add the movie to the list")]
        public void WhenIEnteredAllTheDetailsCorrectlyIShouldAddTheMovieToTheList()
        {
                _result = _movieService.AddMovie(_movieName, _moviePlot, _releaseDate, _actor, _producer);
        }

        [Then(@"I get a confirmation message as '([^']*)'")]
        public void ThenIGetAConfirmationMessageAs(string p0)
        {
            Assert.Equal(_result, p0);
        }

        [Then(@"I get a error message as '([^']*)'")]
        public void ThenIGetAErrorMessageAs(string p0)
        {
            Assert.Equal(_result, p0);
        }



        //get movie from the  list

        [When(@"I asked for movies")]
        public void WhenIAskedForMovies()
        {
            _movies = _movieService.GetMovieList();
        }

        [Then(@"I should get these movies")]
        public void ThenIShouldGetTheseMovies(Table table)
        {
            table.CompareToSet(_movies); ;
        }

        [BeforeScenario ("GetMovieList")]
        public void AddMovie()
        {
            _movieService.AddMovie("bahubali", "action", DateTime.Parse("12/11/2000"), "salman", "Disney");
        }
    }
}
