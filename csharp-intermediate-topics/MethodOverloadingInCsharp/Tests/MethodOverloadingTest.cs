using MethodOverloadingInCsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class MethodOverloadingTest
    {
        [Fact]
        public void WhenOverloadedMethodsWithDifferentParamterCounsAreCalled_ThenTheyShouldRetrunTheCorrectValues() 
        {
            // Arrange.
            var program = new Program();

            // Act.
            var val1 = program.AddNumbers(3,3);
            var val2 = program.AddNumbers(1,2,3);

            // Assert.
            Assert.Equal(val1, val2);
        }

        [Fact]
        public void WhenOverloadedMethodsWithDifferentParamterTypeAreCalled_ThenTheyShouldRetrunTheCorrectValues()
        {
            // Arrange.
            var program = new Program();

            // Act.
            var val1 = program.Append(0);
            var val2 = program.Append("zero");

            // Assert.
            Assert.Equal("Value is: 0", val1);
            Assert.Equal("Value is: zero", val2);
        }

        [Fact]
        public void WhenOverloadedMethodsWithDifferentParamterOrderAreCalled_ThenTheyShouldRetrunTheCorrectValues()  
        {
            // Arrange.
            var program = new Program();

            // Act.
            var val1 = program.Order(0,"item");
            var val2 = program.Order("item",0);

            // Assert.
            Assert.Equal(val1, val2);
        }
    }
}
