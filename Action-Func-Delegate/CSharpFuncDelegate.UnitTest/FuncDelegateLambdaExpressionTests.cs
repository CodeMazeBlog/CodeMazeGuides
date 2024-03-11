using CSharp_Func_Delegate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFuncDelegate.UnitTest
{
    [TestClass]
    public class FuncDelegateLambdaExpressionTests
    {
        [TestMethod]
        public void ProcessBmiWithNoInputParametersFunc_ReturnsCorrectBmi()
        {
            // Arrange
            FuncDelegateLambdaExpression funcDelegateLambdaExpression = new FuncDelegateLambdaExpression();
            Func<double> processBmiFunc = funcDelegateLambdaExpression.ProcessBmiWithNoInputParametersFunc;
            double expectedBmi = 24.49; 

            // Act
            double actualBmi = processBmiFunc();

            // Assert
            Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
        }

        [TestMethod]
        public void ProcessBmiWithInputParametersFunc_ReturnsCorrectBmi()
        {
            // Arrange
            FuncDelegateLambdaExpression funcDelegateLambdaExpression = new FuncDelegateLambdaExpression();
            Func<double, double, double> processBmiFunc = funcDelegateLambdaExpression.ProcessBmiWithInputParametersFunc;
            double height = 175d;
            double weight = 75d;
            double expectedBmi = 24.49;

            // Act
            double actualBmi = processBmiFunc(height, weight);

            // Assert
            Assert.AreEqual(expectedBmi, actualBmi, 0.01, "BMI values don't match");
        }
    }
}
