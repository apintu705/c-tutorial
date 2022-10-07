using System;
using TechTalk.SpecFlow;

namespace BddImplementation.StepDefinitions
{
    [Binding]
    public class AddMovieFeatureStepDefinitions
    {
        [Given(@"I have an application which stores movies with it's details")]
        public void GivenIHaveAnApplicationWhichStoresMoviesWithItsDetails()
        {
            throw new PendingStepException();
        }

        [Given(@"I entered MovieName as '([^']*)'")]
        public void GivenIEnteredMovieNameAs(string bahubali)
        {
            throw new PendingStepException();
        }

        [Given(@"I entered MoviePlot as '([^']*)'")]
        public void GivenIEnteredMoviePlotAs(string action)
        {
            throw new PendingStepException();
        }

        [Given(@"I entered ReleaseDate as '([^']*)'")]
        public void GivenIEnteredReleaseDateAs(string p0)
        {
            throw new PendingStepException();
        }

        [Given(@"I entered Actors as '([^']*)'")]
        public void GivenIEnteredActorsAs(string salman)
        {
            throw new PendingStepException();
        }

        [Given(@"I entered Producer as '([^']*)'")]
        public void GivenIEnteredProducerAs(string disney)
        {
            throw new PendingStepException();
        }

        [When(@"I entered all the details correctly i should add the movie to the list")]
        public void WhenIEnteredAllTheDetailsCorrectlyIShouldAddTheMovieToTheList()
        {
            throw new PendingStepException();
        }

        [Then(@"I get a confirmation message as '([^']*)'")]
        public void ThenIGetAConfirmationMessageAs(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I asked for movies")]
        public void WhenIAskedForMovies()
        {
            throw new PendingStepException();
        }

        [Then(@"I should get these movies")]
        public void ThenIShouldGetTheseMovies(Table table)
        {
            throw new PendingStepException();
        }
    }
}
