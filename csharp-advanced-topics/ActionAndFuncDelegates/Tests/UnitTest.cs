using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WhenFuncInvoke_ThenGenerateFilteredArray()
        {
            //Assign
            string[] sampleArray = { "Banana", "Mango", "Raspberry", "Papaya", "Cranberry", "Apple", "Plum", "Grapes", "Blueberry", "Pineapple", "Strawberry" };
            string substring = "ap";
            string[] expectedResults = { "Papaya", "Apple", "Grapes", "Pineapple" };

            FuncDelegates funcDelegates = new(sampleArray, substring);

            //Act
            funcDelegates.FuncDelegateWithAnonymousMethod();
            List<string> output = funcDelegates.Results;
            string r = string.Join(",", output);
            string s = string.Join(",", expectedResults);

            //assert
            Assert.That(s, Is.EqualTo(r));
        }

        [Test]
        public void WhenActionDelegateWithLambdaExpInvoke_ThenGenerateFilteredArray()
        {
            //Assign
            string[] sampleArray = { "Banana", "Mango", "Raspberry", "Papaya", "Cranberry", "Apple", "Plum", "Grapes", "Blueberry", "Pineapple", "Strawberry" };
            string substring = "pp";
            string[] expectedResults = { "Apple", "Pineapple" };

            ActionDelegates actionDelegates = new(sampleArray, substring);

            //Act
            actionDelegates.ActionDelegateWithLambdaExpression();
            List<string> output = actionDelegates.Results;
            string r = string.Join(",", output);
            string s = string.Join(",", expectedResults);

            //assert
            Assert.That(s, Is.EqualTo(r));
        }
        
        [TestCase(null, "berry")]
        [TestCase(new string[] { "Banana", "Mango", "Raspberry", "Papaya" }, "")]
        [TestCase(null, null)]
        public void GivenInvalidInput_WhenFuncInvoke_ThenGenerateErrorMessage(string[] arr, string substr)
        {
            //assign
            string expectedError = "Input Error!!";

            //Act
            FuncDelegates funcDelegates = new(arr, substr);
            funcDelegates.FuncDelegateWithParameterizedMethod();
            
            //Assert
            Assert.That(expectedError, Is.EqualTo(funcDelegates.Message));            
        }
    }
}