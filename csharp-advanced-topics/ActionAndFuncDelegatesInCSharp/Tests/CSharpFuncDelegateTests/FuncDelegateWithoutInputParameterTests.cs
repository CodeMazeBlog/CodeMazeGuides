namespace CSharpFuncDelegateTests
{
    using CSharp_Func_Delegate;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FuncDelegateWithoutInputParameterTests
    {
        [TestMethod]
        public void ProcessBmi_ReturnsCorrectBmi()
        {
            // Arrange
            FuncDelegateWithoutInputParameter funcDelegateWithoutInputParameter = new FuncDelegateWithoutInputParameter();
            double expectedBmi = 24.49;

            // Act
            double actualBmi = funcDelegateWithoutInputParameter.ProcessBmi();

            // Assert
            Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
        }
    }
}