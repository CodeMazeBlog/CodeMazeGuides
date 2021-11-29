using Xunit;
using System;

namespace Tests
{
    public class FuncDelegatesUnitTest
    {
        static string FullDetails(int age, string name)
        {
            return $"My name is {name} and i am {age} years old";
        }

        [Theory]
        [InlineData(23, "Umoh", "My name is Umoh and i am 23 years old")]
        [InlineData(24, "John", "My name is John and i am 24 years old")]
        public void whenNameAndAgeIsEntered_thenConfirmFullDetails(int age, string name, string expected)
        {
            var funcs = FullDetails;

            var actual = funcs(age, name);

            Assert.Equal(expected, actual);
        }
    }
}
