namespace BehaviorDrivenDevelopment.Tests.StepDefinitions
{
    [Binding]
    public class HelpersStepDefinitions
    {
        ScenarioContext scenarioContext;

        public HelpersStepDefinitions(ScenarioContext context)
        {
            scenarioContext = context;
        }

        [Given(@"the first number is (\d+)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            scenarioContext["FirstNumber"] = p0;
        }

        [When(@"the second number is (\d+)")]
        [Given(@"the second number is (\d+)")]
        public void WhenTheSecondNumberIs(int p0)
        {
            scenarioContext["SecondNumber"] = p0;
        }

        [Then(@"the result should be (\d+)")]
        public void ThenTheResultShouldBe(int p0)
        {
            var result = Helpers.SumTwoNumbers((int)scenarioContext["FirstNumber"], 
                (int)scenarioContext["SecondNumber"]);
            
            Assert.IsTrue(result == p0);
        }

        [Then(@"the subtract result should be (\d+)")]
        public void ThenTheSubtractResultShouldBe(int p0)
        {
            var result = Helpers.SubtractTwoNumbers((int)scenarioContext["FirstNumber"], 
                (int)scenarioContext["SecondNumber"]);
            
            Assert.IsTrue(result == p0);
        }

        [Given(@"the third number is (\d+)")]
        public void GivenTheThirdNumberIs(int p0)
        {
            scenarioContext["ThirdNumber"] = p0;
        }

        [Then(@"the average is (\d+)")]
        public void ThenTheAverageIs(int p0)
        {
            var result = Helpers.GetAverage((int)scenarioContext["FirstNumber"], 
                (int)scenarioContext["SecondNumber"], 
                (int)scenarioContext["ThirdNumber"]);

            Assert.IsTrue(result == p0);
        }

    }
}
