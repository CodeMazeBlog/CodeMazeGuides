namespace BehaviorDrivenDevelopment.Tests.StepDefinitions
{
    [Binding]
    public class ExtensionsStepDefinitions
    {
        ScenarioContext scenarioContext;
        public ExtensionsStepDefinitions(ScenarioContext context) 
        {
            scenarioContext = context;
        }

        [Given(@"the phrase prefix is (.*).")]
        public void GivenThePhrasePrefixIsPhrase(string prefix)
        {
            scenarioContext["Prefix"] = prefix;
        }


        [When(@"the phrase is (.*)")]
        public void WhenThePhraseIs(string phrase)
        {
            scenarioContext["Phrase"] = phrase;
        }

        [Then(@"the word count is (\d+)")]
        public void ThenTheWordCountIs(int count)
        {
            var _count = ($"{(string)scenarioContext["Prefix"]}{(string)scenarioContext["Phrase"]}").GetWordCount();
            Assert.IsTrue(count == _count);
        }

        [Then(@"the char count is (\d+)")]
        public void ThenTheCharCountIs(int count)
        {
            var _count = ($"{(string)scenarioContext["Prefix"]}{(string)scenarioContext["Phrase"]}").GetCharCount();
            Assert.IsTrue(count == _count);
        }


    }
}
