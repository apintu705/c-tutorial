using CalculatorBdd.cs;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowCalculator.Speces.StepDefinitions
{
    [Binding]
    public class CalculatorStepDefinitions
    {
        private readonly Calculator _calculator = new();
        private int _result;
        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            _calculator.FirstNumber = p0;
        }

        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {
            _calculator.SecondNumber = p0;
        }

        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            _result = _calculator.Add();
        }

        [When(@"the two numbers are subtracted")]
        public void WhenTheTwoNumbersAreSubtracted()
        {
            _result = _calculator.Sub();
        }


        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            _result.Should().Be(p0);
        }
    }
}
