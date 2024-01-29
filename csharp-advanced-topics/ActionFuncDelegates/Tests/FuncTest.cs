using ActionFuncDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class FuncDelegatesTests
    {

        [Fact]
        public void FuncDelegate_ShouldReturnResult()
        {
            // Act
            int result = FuncDelegates.FuncDelegate();

            // Assert
            Assert.Equal(30, result);
        }

        [Fact]
        public void FuncDelegateWithAnonymous_ShouldReturnResult()
        {
            // Act
            int result = FuncDelegates.FuncDelegateWithAnonymous();

            // Assert
            Assert.Equal(40, result);
        }

        [Fact]
        public void FuncDelegateWithLambda_ShouldReturnResult()
        {
            // Act
            int result = FuncDelegates.FuncDelegateWithLambda();

            // Assert
            Assert.Equal(100, result);
        }
    }
}

