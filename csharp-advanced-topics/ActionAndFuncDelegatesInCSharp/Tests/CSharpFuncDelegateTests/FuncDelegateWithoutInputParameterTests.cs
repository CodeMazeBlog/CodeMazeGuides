namespace CSharpFuncDelegateTests
{
    using CSharp_Func_Delegate;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FuncDelegateWithoutInputParameterTests
    {
        [TestMethod]
        public void WhenInvokingFuncWithNoInputParameters_ThenFuncDelegateExecutesTheReferencedMethod()
        {
            // Arrange
            var funcDelegateWithoutInputParameter = new FuncDelegateWithoutInputParameter();
            var processBmiFunc = funcDelegateWithoutInputParameter.ProcessBmi;
            var expectedBmi = 24.49d;

            // Act
            var actualBmi = processBmiFunc();

            // Assert
            Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
        }
    }
}