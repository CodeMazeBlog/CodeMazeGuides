using ActionAndFuncDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class FuncDelegateUnitTest
    {
        [Fact]
        public void GivenFuncWithAnon_WhenCalled_ThenReturnsModulus()
        {
            //Arrange
            int one = 67;
            int two = 10;

            FuncDelegate funcDelegate = new();

            //Act            
            int result = funcDelegate.FuncWithAnon(one, two);

            //Assert
            Assert.Equal(7, result);
        }

        [Fact]
        public void GivenFuncWithLambda_WhenCalled_ThenReturnsModulus()
        {
            //Arrange
            int one = 98;
            int two = 10;

            FuncDelegate funcDelegate = new();

            //Act            
            int result = funcDelegate.FuncWithLambda(one, two);

            //Assert
            Assert.Equal(8, result);
        }
    }
}
