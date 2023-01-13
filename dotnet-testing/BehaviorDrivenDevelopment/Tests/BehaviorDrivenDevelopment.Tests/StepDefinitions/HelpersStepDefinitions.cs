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
        public void WhenTheSecondNumberIs(int p0)
        {
            scenarioContext["SecondNumber"] = p0;
        }

        [Then(@"the result should be (\d+)")]
        public void ThenTheResultShouldBe(int p0)
        {
            var result = Helpers.SumTwoNumbers((int)scenarioContext["FirstNumber"], (int)scenarioContext["SecondNumber"]);
            scenarioContext["Result"] = p0;
            Assert.IsTrue(result == p0);
        }

        [Then(@"the subtract result should be (\d+)")]
        public void ThenTheSubtractResultShouldBe(int p0)
        {
            var result = Helpers.SubtractTwoNumbers((int)scenarioContext["FirstNumber"], (int)scenarioContext["SecondNumber"]);
            scenarioContext["Result"] = p0;
            Assert.IsTrue(result == p0);
        }
    }
}
