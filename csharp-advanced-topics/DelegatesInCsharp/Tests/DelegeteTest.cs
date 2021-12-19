using DelegatesInCSharp;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class DelgeteTest
    {
        [Theory]
        [InlineData(5)]
        public void SelectFuncDelegateTest(int actualTotalItems)
        {
            //Arrange
            MathOperation mathOperation = new MathOperation();

            //Creating a list of numbers between 1 and 5.
            IEnumerable<int> items = Enumerable.Range(1, 5);


            //Act
            //Passing ProcessSingleDigit as an argument into Select method.
            var processedItems= items.Select(mathOperation.ProcessSingleDigit);

            //On calling the ToList method on the processedItems collection the Select method 
            //is called and executes the ProcessSingleDigit method for each item in the collection.
            //This process is called Deferred Execution.

            var resultItemCollection = processedItems.ToList();

            //Assert
            Assert.Equal(actualTotalItems, resultItemCollection.Count);
        }

        [Theory]
        [InlineData(3)]
        public void CustomFuncDelegateTest(int actualValue)
        {
            //Arrange
            MathOperation mathOperation = new MathOperation();

            //Act
            //Passing  Lambda expression as an argument into the PerformMathOperation
            var result = mathOperation.PerformMathsOperation((input1, input2) => { return input1 + input2; });

            //Assert
            Assert.Equal(actualValue, result);
        }

        [Theory]
        [InlineData(3)]
        public void CustomAddFuncDelegateTest(int actualValue)
        {
            //Arrange
            MathOperation mathOperation = new MathOperation();

            //Act
            //Passing  Add method as an argument into the PerformMathOperation
            var result = mathOperation.PerformMathsOperation(mathOperation.Add);

            //Assert
            Assert.Equal(actualValue, result);
        }

        [Fact]
        public void ForeachActionDelegateTest()
        {
            //Arrange
            MathOperation mathOperation = new MathOperation();

            //Creating a list of numbers between 1 and 5.
            IEnumerable<int> items = Enumerable.Range(1, 5);


            //Act
            //Passing ProcessSingleIntMessage method as an argument into Foreach method.
            //Foreach method will be executed for each item in the collection passing each 
            //item to ProcessSingleIntMessage
            items.ToList().ForEach(mathOperation.ProcessSingleIntMessage);

            //Assert 
            Assert.Equal("My Value is:5", mathOperation.Message);
        }

        [Fact]
        public void CustomActionDelegateTest()
        {
            //Arrange
            MathOperation mathOperation = new MathOperation();
            string localMessage = string.Empty;

            //Act
            //Passing Lambda Expression as an argument into the DisplayMathResult.
            mathOperation.DisplayMathResult((message1, message2) => { localMessage = message1 + message2; });

            //Assert
            Assert.Equal("message onemessage two", localMessage);
        }

        [Fact]
        public void CustomDisplayMessageActionDelegateTest()
        {
            //Arrange
            MathOperation mathOperation = new MathOperation();
            string localMessage = string.Empty;

            //Act
            //Passing ProcessMessage as an argument into the DisplayMathResult.
            mathOperation.DisplayMathResult(mathOperation.ProcessMessage);

            //Assert
            Assert.Equal("message onemessage two", mathOperation.Message);
        }




    }
}
