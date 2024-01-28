using CheckIfObjectIsNumber;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void GivenMultipleTypes_WhenCheckedWithEqualityOperator_ThenReturnsBoolean()
        {
            // Act 
            var checkIntIsTrue = Program.CheckIfIntegerWithEqualityOperator(-15);
            var checkFloatIsFalse = Program.CheckIfIntegerWithEqualityOperator(2.54f);
            var checkStringIsFalse = Program.CheckIfIntegerWithEqualityOperator("123");

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
            var resultFromFloat = Program.CheckIfFloatWithExplicitCasting(floatValue);

            // Assert
            Assert.Equal(floatValue, resultFromFloat);
            Assert.Throws<InvalidCastException>(() => Program.CheckIfFloatWithExplicitCasting(integerValue));
            Assert.Throws<InvalidCastException>(() => Program.CheckIfFloatWithExplicitCasting(doubleValue));
            Assert.Throws<InvalidCastException>(() => Program.CheckIfFloatWithExplicitCasting(stringValue));
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
            var resultFromNegativeInteger = Program.CheckIfShortUsingConvert(negativeIntegerValue);
            var resultFromInteger = Program.CheckIfShortUsingConvert(integerValue);
            var resultFromFloat = Program.CheckIfShortUsingConvert(floatValue);
            var resultFromString = Program.CheckIfShortUsingConvert(stringValue);

            // Assert
            Assert.Equal(negativeIntegerValue, resultFromNegativeInteger);
            Assert.Equal(integerValue, resultFromInteger);
            Assert.Equal(-5, resultFromFloat);
            Assert.Equal(123, resultFromString);
            Assert.Throws<OverflowException>(() => Program.CheckIfShortUsingConvert(doubleValue));
            Assert.Throws<OverflowException>(() => Program.CheckIfShortUsingConvert(decimalValue));
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
            Assert.True(Program.CheckIfFloatWithIsOperator(floatValue));
            Assert.False(Program.CheckIfFloatWithIsOperator(integerValue));
            Assert.False(Program.CheckIfFloatWithIsOperator(doubleValue));
            Assert.False(Program.CheckIfFloatWithIsOperator(stringValue));
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
            Assert.Equal(integerValue, Program.ConvertToIntWithAsOperator(integerValue));
            Assert.Equal(0, Program.ConvertToIntWithAsOperator(floatValue));
            Assert.Equal(0, Program.ConvertToIntWithAsOperator(doubleValue));
            Assert.Equal(0, Program.ConvertToIntWithAsOperator(stringValue));
            Assert.Equal(0, Program.ConvertToIntWithAsOperator(charactersValue));
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