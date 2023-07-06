using ActionAndFuncDelegates.Logic;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesTest
{
    public  class FuncDelegateTest
    {
        private  FuncDelegateInCSharp sut;


        [Fact]
        public void ExecuteWithoutParameter_ShouldReturnTrueIfNumberIsEven()
        {
            sut = new(new Counter(10));
            var output = sut.ExecuteWithoutParameter();

            Assert.True(output);
        }

        [Fact]
        public void ExecuteWithoutParameter_ShouldReturnFalseIfNumberIsNotEven()
        {
            sut = new(new Counter(9));
            var output = sut.ExecuteWithoutParameter();

            Assert.False(output);
        }

        [Fact]
        public void ExecuteWithParameter_ShouldReturnTrueIfCountIsGreaterThanValue()
        {
            sut = new(new Counter(40));
            var output = sut.ExecuteWithParameter();

            Assert.True(output);
        }

        [Fact]
        public void ExecuteWithParameter_ShouldReturnFalseIfCountIsNotGreaterThanValue()
        {
            sut = new(new Counter(20));
            var output = sut.ExecuteWithParameter();

            Assert.False(output);
        }

        [Fact]
        public void ExecuteWithoutParameterUsingAnonymousMethod_ShouldReturnTrueIfNumberIsEven()
        {
            sut = new(new Counter(10));           
            var output = sut.ExecuteWithoutParameterUsingAnonymousMethod();
            
            Assert.True(output);
        }

        [Fact]
        public void ExecuteWithoutParameterUsingAnonymousMethod_ShouldReturnFalseIfNumberNotIsEven()
        {
            sut = new(new Counter(9));
            var output = sut.ExecuteWithoutParameterUsingAnonymousMethod();

            Assert.False(output);
        }

        [Fact]
        public void ExecuteWithParameterUsingAnonymousMethod_ShouldReturnTrueIfCountIsGreaterThanValue()
        {
            sut = new(new Counter(40));
            var output = sut.ExecuteWithParameterUsingAnonymousMethod();

            Assert.True(output);
        }

        [Fact]
        public void ExecuteWithParameterUsingAnonymousMethod_ShouldReturnFalseIfCountIsNotGreaterThanValue()
        {
            sut = new(new Counter(20));
            var output = sut.ExecuteWithParameterUsingAnonymousMethod();

            Assert.False(output);
        }

        [Fact]
        public void ExecuteWithoutParameterUsingLambdaExpressions_ShouldReturnTrueIfNumberIsEven()
        {
            sut = new(new Counter(10));
            var output = sut.ExecuteWithoutParameterUsingLambdaExpressions();

            Assert.True(output);
        }

        [Fact]
        public void ExecuteWithoutParameterUsingLambdaExpressions_ShouldReturnFalseIfNumberIsNotEven()
        {
            sut = new(new Counter(9));
            var output = sut.ExecuteWithoutParameterUsingLambdaExpressions();

            Assert.False(output);
        }

        [Fact]
        public void ExecuteWithParameterUsingLambdaExpressions_ShouldReturnTrueIfCountIsGreaterThanValue()
        {
            sut = new(new Counter(40));
            var output = sut.ExecuteWithParameterUsingLambdaExpressions();

            Assert.True(output);
        }

        [Fact]
        public void ExecuteWithParameterUsingLambdaExpressions_ShouldReturnFalseIfCountIsNotGreaterThanValue()
        {
            sut = new(new Counter(20));
            var output = sut.ExecuteWithParameterUsingLambdaExpressions();

            Assert.False(output);
        }
    }
}
