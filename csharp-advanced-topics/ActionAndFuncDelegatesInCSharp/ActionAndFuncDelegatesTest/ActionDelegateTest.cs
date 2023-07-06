using ActionAndFuncDelegates.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesTest
{
    public class ActionDelegateTest
    {
        private ActionDelegateInCSharp sut;

        [Theory]
        [InlineData(10, 11)]
        public void ExecuteWithoutParameter_ShouldReturnNumberWithIncrementOfOne(int testvalue, int expected)
        {
            sut = new(new Counter(testvalue));
            sut.ExecuteWithoutParameter();

            Assert.Equal(expected, sut.counter.Count);
        }

        [Theory]
        [InlineData(10, 30)]
        public void ExecuteWithParameter_ShouldReturnNumberWithIncrementOftwenty(int testvalue, int expected)
        {
            sut = new(new Counter(testvalue));
            sut.ExecuteWithParameter();

            Assert.Equal(expected, sut.counter.Count);
        }

        [Theory]
        [InlineData(10, 11)]
        public void ExecuteWithoutParameterUsingAnonymousMethod_ShouldReturnNumberWithIncrementOfOne(int testvalue, int expected)
        {
            sut = new(new Counter(testvalue));
            sut.ExecuteWithoutParameterUsingAnonymousMethod();

            Assert.Equal(expected, sut.counter.Count);
        }

        [Theory]
        [InlineData(10, 30)]
        public void ExecuteWithParameterUsingAnonymousMethod_ShouldReturnNumberWithIncrementOftwenty(int testvalue, int expected)
        {
            sut = new(new Counter(testvalue));
            sut.ExecuteWithParameterUsingAnonymousMethod();

            Assert.Equal(expected, sut.counter.Count);
        }

        [Theory]
        [InlineData(10, 11)]
        public void ExecuteWithoutParameterUsingLambdaExpressions_ShouldReturnNumberWithIncrementOfOne(int testvalue, int expected)
        {

            sut = new(new Counter(testvalue));
            sut.ExecuteWithoutParameterUsingLambdaExpressions();

            Assert.Equal(expected, sut.counter.Count);
        }

        [Theory]
        [InlineData(10, 30)]
        public void ExecuteWithParameterUsingLambdaExpressions_ShouldReturnNumberWithIncrementOftwenty(int testvalue, int expected)
        {
            sut = new(new Counter(testvalue));
            sut.ExecuteWithParameterUsingLambdaExpressions();

            Assert.Equal(expected, sut.counter.Count);
        }
    }
}
