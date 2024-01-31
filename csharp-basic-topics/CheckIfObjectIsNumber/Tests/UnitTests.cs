using Xunit;
using CheckIfObjectIsNumber;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void GivenMultipleTypes_WhenCheckedWithEqualityOperator_ThenReturnsBoolean()
        {
            // Act 
            var checkIntIsTrue = Methods.CheckIfIntegerWithEqualityOperator(-15);
            var checkFloatIsFalse = Methods.CheckIfIntegerWithEqualityOperator(2.54f);
            var checkStringIsFalse = Methods.CheckIfIntegerWithEqualityOperator("123");

            // Assert
            Assert.True(checkIntIsTrue);
            Assert.False(checkFloatIsFalse);
            Assert.False(checkStringIsFalse);
        }

        [Fact]
        public void GivenMultipleTypes_WhenCheckedWithExplicitCasting_ThenReturnsFloat()
        {
            // Arrange
            var integerValue = -15;
            var floatValue = 2.54f;
            var doubleValue = -4.7513247659008d;
            var stringValue = "123";

            // Act
            var resultFromFloat = Methods.CheckIfFloatWithExplicitCasting(floatValue);

            // Assert
            Assert.Equal(floatValue, resultFromFloat);
            Assert.Throws<InvalidCastException>(() => Methods.CheckIfFloatWithExplicitCasting(integerValue));
            Assert.Throws<InvalidCastException>(() => Methods.CheckIfFloatWithExplicitCasting(doubleValue));
            Assert.Throws<InvalidCastException>(() => Methods.CheckIfFloatWithExplicitCasting(stringValue));
        }

        [Fact]
        public void GivenMultipleTypes_WhenCheckedWithConvert_ThenReturnsShort()
        {
            // Arrange
            var negativeIntegerValue = -5;
            var integerValue = 0;
            var floatValue = -4.75f;
            var stringValue = "123";
            var doubleValue = double.MaxValue;
            var decimalValue = decimal.MaxValue;

            // Act
            var resultFromNegativeInteger = Methods.CheckIfShortUsingConvert(negativeIntegerValue);
            var resultFromInteger = Methods.CheckIfShortUsingConvert(integerValue);
            var resultFromFloat = Methods.CheckIfShortUsingConvert(floatValue);
            var resultFromString = Methods.CheckIfShortUsingConvert(stringValue);

            // Assert
            Assert.Equal(negativeIntegerValue, resultFromNegativeInteger);
            Assert.Equal(integerValue, resultFromInteger);
            Assert.Equal(-5, resultFromFloat);
            Assert.Equal(123, resultFromString);
            Assert.Throws<OverflowException>(() => Methods.CheckIfShortUsingConvert(doubleValue));
            Assert.Throws<OverflowException>(() => Methods.CheckIfShortUsingConvert(decimalValue));
        }

        [Fact]
        public void GivenMultipleTypes_WhenComparedWithIsOperator_ThenReturnsBoolean()
        {
            // Arrange
            var integerValue = -15;
            var floatValue = 2.54f;
            var doubleValue = -4.24708d;
            var stringValue = "123";

            // Act & Assert
            Assert.True(Methods.CheckIfFloatWithIsOperator(floatValue));
            Assert.False(Methods.CheckIfFloatWithIsOperator(integerValue));
            Assert.False(Methods.CheckIfFloatWithIsOperator(doubleValue));
            Assert.False(Methods.CheckIfFloatWithIsOperator(stringValue));
        }

        [Fact]
        public void GivenMultipleTypes_WhenConvertToIntegerWithAsOperator_ThenReturnsInteger()
        {
            // Arrange
            var integerValue = -15;
            var floatValue = 2.54f;
            var doubleValue = -4.24708d;
            var stringValue = "123";
            var charactersValue = "test";

            // Act & Assert
            Assert.Equal(integerValue, Methods.ConvertToIntWithAsOperator(integerValue));
            Assert.Equal(0, Methods.ConvertToIntWithAsOperator(floatValue));
            Assert.Equal(0, Methods.ConvertToIntWithAsOperator(doubleValue));
            Assert.Equal(0, Methods.ConvertToIntWithAsOperator(stringValue));
            Assert.Equal(0, Methods.ConvertToIntWithAsOperator(charactersValue));
        }

        [Fact]
        public void GivenMultipleTypes_WhenCheckIfNumberWithExtensionMethod_ThenReturnsBoolean()
        {
            // Arrange
            var shortValue = -15;
            var floatValue = 2.54f;
            var doubleValue = -4.24708d;
            var stringValue = "123";
            var charactersValue = "test";
            var listIntegers = new List<int> { 0, 9, 8, -2 };

            // Act & Assert
            Assert.True(shortValue.IsNumber());
            Assert.True(floatValue.IsNumber());
            Assert.True(doubleValue.IsNumber());
            Assert.False(stringValue.IsNumber());
            Assert.False(charactersValue.IsNumber());
            Assert.False(listIntegers.IsNumber());
        }
    }
}