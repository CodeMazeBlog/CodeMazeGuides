

using ActionAndFuncInCsharpConsole;

namespace ActionsAndFuncInCsharpTests;


    public class FuncExampleTests
    {
        
        [Fact]
        public void PerformCalculate_WithCustomFunction_ShouldReturnFunctionResultPlusOne()
        {
            // Arrange
            var funcExample = new FuncExample();
            Func<int, int, int> customFunction = (a, b) => a * b;
            var expectedResult = 10;

            // Act
          var actual =  funcExample.PerformCalculate(3, 3, customFunction);
            
            funcExample.DoSomeWork();
            

            // Assert
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public void PerformCalculate_WithSumFunction_ShouldReturnSum()
        {
            // Arrange
            var funcExample = new FuncExample();
            var expectedResult = 6;

            // Act
     
            var actual =  funcExample.PerformCalculate(1, 4, funcExample.Sum);
          
           
            

            // Assert
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public void PerformCalculate_WithDifferenceFunction_ShouldReturnDifference()
        {
            // Arrange
            var funcExample = new FuncExample();
            var expectedResult = 3;

         
           var actual = funcExample.PerformCalculate(4, 2, funcExample.Difference);
          
           
           

            // Assert
            Assert.Equal(expectedResult, actual );
        }

        [Fact]
        public void GetRandomNumber_ShouldReturnRandomNumber()
        {
            // Arrange
            var funcExample = new FuncExample();
            var expectedResult = true;

            // Act
            var randomNumber = funcExample.GetRandomNumber();
            var isInRange = randomNumber >= 1 && randomNumber <= 100;

            // Assert
            Assert.Equal(expectedResult, isInRange);
        }
    }
