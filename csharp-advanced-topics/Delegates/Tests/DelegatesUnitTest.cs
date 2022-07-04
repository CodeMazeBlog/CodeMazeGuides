using Delegates.After;
using Delegates.Before;
using System;
using Xunit;

namespace Tests
{
    public class DelegatesUnitTest
    {
        [Fact]
        public void GivenPrintInUpperCase_WhenStringIsNotNull_ThenReturnStringInUpperCase()
        {
            var result = WithoutDelegates.PrintInUpperCase("Delegates in C#.");

            Assert.Equal("DELEGATES IN C#.", result);
        }

        [Fact]
        public void GivenPrintInLowerCase_WhenStringIsNotNull_ThenReturnStringInLowerCase()
        {
            var result = WithoutDelegates.PrintInLowerCase("Delegates in C#.");

            Assert.Equal("delegates in c#.", result);
        }

        [Fact]
        public void GivenPrintInUpperCase_WhenStringIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => WithoutDelegates.PrintInUpperCase(null));
        }

        [Fact]
        public void GivenPrintInLowerCase_WhenStringIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => WithoutDelegates.PrintInLowerCase(null));
        }

        [Fact]
        public void GivenPrintProcessedText_WhenStringIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(() 
                => WithDelegates.PrintProcessedText(null, x => Console.WriteLine("") , x => x.ToUpper()));
        }

        [Fact]
        public void GivenPrintProcessedText_WhenPrintIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(()
                => WithDelegates.PrintProcessedText("", null , x => x.ToUpper()));
        }

        [Fact]
        public void GivenPrintProcessedText_WhenOperationIsNull_ThenThrowException()
        {
            Assert.Throws<ArgumentNullException>(()
                => WithDelegates.PrintProcessedText("", x => Console.WriteLine(""), null));
        }

        [Fact]
        public void GivenPrintProcessedText_WhenAllIsNotNull_ThenReturnStringInUpperCase()
        {
            var result = WithDelegates.PrintProcessedText("Delegates in C#.", x => Console.WriteLine(""), x => x.ToUpper());

            Assert.Equal("DELEGATES IN C#.", result);
        }

        [Fact]
        public void GivenPrintProcessedText_WhenAllIsNotNull_ThenReturnStringInLowerCase()
        {
            var result = WithDelegates.PrintProcessedText("Delegates in C#.", x => Console.WriteLine(""), x => x.ToLower());

            Assert.Equal("delegates in c#.", result);
        }
    }
}