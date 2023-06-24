using ActionAndFuncDelegatesDemo;
using System;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFunc()
        {
            //Assign
            string[] sampleArray = { "Banana", "Mango", "Raspberry", "Papaya", "Cranberry", "Apple", "Plum", "Grapes", "Blueberry", "Pineapple", "Strawberry" };
            string substring = "ap";
            string[] expectedResults = { "Papaya", "Apple", "Grapes", "Pineapple" };

            FuncDelegates funcDelegates = new(sampleArray, substring);
            
            //Act
            funcDelegates.FuncDelegateWithAnonymousMethod();
            List<string> output = funcDelegates.results;
            string r = string.Join(",", output); 
            string s = string.Join(",", expectedResults);

            //assert
            Assert.That(s, Is.EqualTo(r));
        }

        [Test]
        public void TestAction()
        {
            //Assign
            string[] sampleArray = { "Banana", "Mango", "Raspberry", "Papaya", "Cranberry", "Apple", "Plum", "Grapes", "Blueberry", "Pineapple", "Strawberry" };
            string substring = "pp";
            string[] expectedResults = { "Apple", "Pineapple" };

            ActionDelegates actionDelegates = new(sampleArray, substring);

            //Act
            actionDelegates.ActionDelegateWithLambdaExpression();
            List<string> output = actionDelegates.results;
            string r = string.Join(",", output);
            string s = string.Join(",", expectedResults);

            //assert
            Assert.That(s, Is.EqualTo(r));
        }
    }
}