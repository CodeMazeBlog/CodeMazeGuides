using System;
using System.IO;
using Xunit;

namespace TypeCheckingAndCastingInCSharp.Tests
{
    public class TypeTestingTests
    {
        [Fact]
        public void WhenUsingTypeOfOnAType_ThenReturnsTheTypeValue()
        {
            // act
            var typeValue = typeof(string);

            // assert
            Assert.IsAssignableFrom<Type>(typeValue);
        }

        [Fact]
        public void WhenUsingTypeOfOnATypeParameter_ThenReturnsTheTypeValue()
        {
            // arrange
            string GetTypeName<T> () => typeof(T).Name;

            // act
            var typeName = GetTypeName<int>();  // Int32
            var typeName2 = GetTypeName<decimal>(); // Decimal

            // assert
            Assert.Equal("Int32", typeName);
            Assert.Equal("Decimal", typeName2);
        }

        [Fact]
        public void WhenGettingTypeFromValue_ThenTypeObjectIsReturned()
        {
            // arrange
            var stringValue = "hello";
            var singleValue = 12.5f;

            // act & assert
            Assert.Equal(typeof(string), stringValue.GetType());
            Assert.Equal(typeof(float), singleValue.GetType());
        }

        [Fact]
        public void WhenTypeTestingAtRunTime_ThenUseGeTypeAndTypeof()
        {
            // arrange 
            var sw = new StringWriter();
            object[] values = { 6, 12.5f, 100M, true, "hello" };

            // act
            foreach (var val in values)
            {
                string? message;
                if (val.GetType().Equals(typeof(int)))
                {
                    message = $"Value {val} is an integer";
                }
                else if (val.GetType().Equals(typeof(decimal)))
                {
                    message = $"Value {val} is a decimal";
                }
                else if (val.GetType().Equals(typeof(float)))
                {
                    message = $"Value {val} is a floating-point value";
                }
                else if (val.GetType().Equals(typeof(bool)))
                {
                    message = $"Value {val} is a boolean";
                }
                else if (val.GetType().Equals(typeof(string)))
                {
                    message = $"Value {val} is a string";
                }
                else
                {
                    message = $"Value {val} belongs to an unknown type";
                }

                sw.WriteLine(message);
            }

            // Value 6 is an integer
            // Value 12.5 is a floating-point value
            // Value 100 is a decimal
            // Value True is a boolean
            // Value hello is a string

            Assert.Equal($"Value 6 is an integer{Environment.NewLine}Value 12.5 is a floating-point value{Environment.NewLine}Value 100 is a decimal{Environment.NewLine}Value True is a boolean{Environment.NewLine}Value hello is a string{Environment.NewLine}", sw.ToString());
        }

        [Fact]
        public void WhenTypeCheckingValues_ThenIsOperatorReturnsBoolean()
        {
            int number = 16;
            string name = "John Smith";

            Assert.True(number is int);     // true
            Assert.True(name is string);    // true
            Assert.False(number is bool);   // false
        }

        [Fact]
        public void WhenCastingValues_ThenUseTypePatterns()
        {
            // arrange
            var message = string.Empty;
            object data = "John Smith";

            // act
            if (data is string name)
            {
                message = $"Hello {name}!";
            }

            // assert
            Assert.Equal("Hello John Smith!", message);
        }
    }
}
