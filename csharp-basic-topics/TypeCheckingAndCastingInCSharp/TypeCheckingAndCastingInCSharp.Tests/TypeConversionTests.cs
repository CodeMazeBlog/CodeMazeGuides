using System;
using System.IO;
using System.Linq;
using TypeCheckingAndCastingInCSharp.Models;
using Xunit;

namespace TypeCheckingAndCastingInCSharp.Tests
{
    public class TypeConversionTests
    {
        [Fact]
        public void WhenAssigningValueToABiggerType_ThenValueGetsImplicitConversion()
        {
            // act
            int number = 10;
            long biggerNumber = number; // biggerNumber contains 10

            // assert
            Assert.Equal(number, biggerNumber);
        }

        [Fact]
        public void WhenAssigningDerivedToBaseType_ThenValueGetsImplicitConversion()
        {
            // act
            Horse horse = new();    // derived type
            Animal animal = horse;  // assign to base type

            // assert
            Assert.Same(animal, horse);
        }

        [Fact]
        public void WhenAssigningValuesToOtherType_ThenUseCastExpressionForExplicitConversion()
        {
            // act
            long biggerNumber = 10;
            int number = (int)biggerNumber;   // number contains 10

            // assert
            Assert.Equal(10, number);
        }

        [Fact]
        public void WhenAssigningBaseToDerivedType_ThenUseCastExpressionForExplicitConversion()
        {
            // act
            Animal animal = new Horse();  // base type variable
            Horse horse = (Horse)animal;    // assign to derived type

            // assert
            Assert.Same(animal, horse);
        }

        [Fact]
        public void WhenAssigningBaseToWrongDerivedType_ThenGetInvalidCastException()
        {
            // act & assert

            Assert.Throws<InvalidCastException>(() =>
            {
                Animal animal = new Monkey();
                Horse horse = (Horse)animal;    // compiles but throws InvalidCastException
            });
        }

        [Fact]
        public void WhenUsingAsOperator_ThenExplicitConversionIsDoneOrReturnsNull()
        {
            // act
            Animal animal = new Horse();

            Horse? horse = animal as Horse; // explicit conversion
            Monkey? monkey = animal as Monkey;  // invalid conversion, monkey contains null

            // assert
            Assert.Same(animal, horse);
            Assert.Null(monkey);
        }

        [Fact]
        public void WhenConvertingFromString_ThenUseParseMethod()
        {
            // act
            int number = int.Parse("10");   // convert string to integer
            bool boolean = bool.Parse("True");  // convert string to boolean

            // assert
            Assert.Equal(10, number);
            Assert.True(boolean);
        }

        [Fact]
        public void WhenConvertingFromString_ThenUseTryParseMethod()
        {
            // act
            var succeed = int.TryParse("10", out var number);
            // succeed == true
            // number == 10

            // assert
            Assert.Equal(10, number);
            Assert.True(succeed);
        }

        [Fact]
        public void WhenConvertingBasicTypes_ThenUseConvertStaticMethods()
        {
            // arrange
            decimal fraction = 12.5M;

            // act
            int integer = Convert.ToInt16(fraction);
            string str = Convert.ToString(fraction);
            bool boolean = Convert.ToBoolean("true");

            // assert
            Assert.Equal(12, integer);
            Assert.Equal("12.5", str);
            Assert.True(boolean);
        }

        [Fact]
        public void WhenConvertingBasicTypesToBytes_ThenUseBitConverter()
        {
            // arrange
            int integer = 1024;
            float fraction = 12.5F;

            // act
            var integerAsBytes = BitConverter.GetBytes(integer);
            var floatAsBytes = BitConverter.GetBytes(fraction);

            // Assert
            Assert.True(integerAsBytes.SequenceEqual(new byte[] { 0, 4, 0, 0 }));
            Assert.True(floatAsBytes.SequenceEqual(new byte[] { 0, 0, 72, 65 }));
        }

        [Fact]
        public void WhenOverloadingCastingOperator_ThenImplicitAndExplicitConversionsWork()
        {
            var currency = new Currency("$", 1950.75M);
            decimal decimalValue = currency;    // decimalValue contains 1950.75

            var anotherDecimal = 775.2M;
            var convertedCurrency = (Currency)anotherDecimal;  // convertedCurrency prints "$775.20"

            Assert.Equal(1950.75M, decimalValue);
            Assert.Equal("$775.20", convertedCurrency.ToString());
        }
    }
}