using FuncDelegates;
using Xunit;

namespace Test
{
    public class FuncDelegatesTests
    {
        [Fact]
        public void InvokeSumViaFuncDelegate_Invokes_Sum_Method_Using_Func_Delegate()
        {
            // Arrange
            int expectedResult = Program.Sum(2, 2);
            // Act
            int actualResult = Program.InvokeSumViaFuncDelegate(2, 2);
            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
