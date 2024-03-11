using CSharp_Func_Delegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFuncDelegate.UnitTest
{
    [TestClass]
    public class FuncDelegateWithInputParameterTests
    {
        [TestMethod]
        public void ProcessBmi_ReturnsCorrectBmi()
        {
            // Arrange
            FuncDelegateWithInputParameter funcDelegateWithoutInputParameter = new FuncDelegateWithInputParameter();
            double height = 175d;
            double weight = 75d;
            double expectedBmi = 24.49;

            // Act
            double actualBmi = funcDelegateWithoutInputParameter.ProcessBmi(height, weight);

            // Assert
            Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
        }
    }
}
