namespace CSharpFuncDelegateTests
{
    using CSharp_Func_Delegate;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FuncDelegateWithInputParameterTests
    {
        [TestMethod]
        public void WhenInvokingFuncWithInputParameters_ThenFuncDelegateExecutesTheReferencedMethod()
        {
            // Arrange
            var funcDelegateWithoutInputParameter = new FuncDelegateWithInputParameter();
            var processBmiFunc = funcDelegateWithoutInputParameter.ProcessBmi;
            var height = 175d;
            var weight = 75d;
            var expectedBmi = 24.49;

            // Act
            var actualBmi = processBmiFunc(height, weight);

            // Assert
            Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
        }
    }
}
