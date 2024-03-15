namespace CSharpFuncDelegateTests
{
    using CSharp_Func_Delegate;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FuncDelegateLambdaExpressionTests
    {
        [TestMethod]
        public void WhenInvokingFuncWithNoInputParameters_ThenFuncDelegateExecutesTheReferencedMethod()
        {
            // Arrange
            var funcDelegateLambdaExpression = new FuncDelegateLambdaExpression();
            var processBmiFunc = funcDelegateLambdaExpression.ProcessBmiWithNoInputParametersFunc;
            var expectedBmi = 24.49d; 

            // Act
            var actualBmi = processBmiFunc();

            // Assert
            Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
        }

        [TestMethod]
        public void WhenInvokingFuncWithInputParameters_ThenFuncDelegateExecutesTheReferencedMethod()
        {
            // Arrange
            var funcDelegateLambdaExpression = new FuncDelegateLambdaExpression();
            var processBmiFunc = funcDelegateLambdaExpression.ProcessBmiWithInputParametersFunc;
            var height = 175d;
            var weight = 75d;
            var expectedBmi = 24.49d;

            // Act
            var actualBmi = processBmiFunc(height, weight);

            // Assert
            Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
        }
    }
}
