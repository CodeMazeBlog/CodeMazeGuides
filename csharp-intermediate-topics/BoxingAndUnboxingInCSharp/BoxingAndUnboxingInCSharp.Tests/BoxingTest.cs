using BoxingAndUnboxingInCSharp;

namespace BoxingAndUnboxing.Test
{
    public class BoxingTest
    {
        [Fact]
        public void GivenAnIntValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = -2147483648;
            object actualValue = Conversion.BoxToInt(-2147483648);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenASByteValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = sbyte.MinValue;
            object actualValue = Conversion.BoxToSbyte(sbyte.MinValue);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAByteValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = byte.MaxValue;
            object actualValue = Conversion.BoxToByte(byte.MaxValue);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenANintValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = nint.MaxValue;
            object actualValue = Conversion.BoxToNint(nint.MaxValue);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenANuintValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = nuint.MaxValue;
            object actualValue = Conversion.BoxToNuint(nuint.MaxValue);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAUintValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = uint.MaxValue;
            object actualValue = Conversion.BoxToUint(uint.MaxValue);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnUShortValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = ushort.MaxValue;
            object actualValue = Conversion.BoxToUshort(ushort.MaxValue);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenALongValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = long.MinValue;
            object actualValue = Conversion.BoxToLong(long.MinValue);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnULongValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = ulong.MaxValue;
            object actualValue = Conversion.BoxToUlong(ulong.MaxValue);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenADoubleValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = double.MaxValue;
            object actualValue = Conversion.BoxToDouble(double.MaxValue);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenADecimalValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = decimal.MaxValue;
            object actualValue = Conversion.BoxToDecimal(decimal.MaxValue);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAFloatValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = float.MaxValue;
            object actualValue = Conversion.BoxToFloat(float.MaxValue);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAShortValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = short.MinValue;
            object actualValue = Conversion.BoxToShort(short.MinValue);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenACharValue_WhenTryToBoxToObject_ThenExecuteBoxing()
        {
            object expectedValue = char.MaxValue;
            object actualValue = Conversion.BoxToChar(char.MaxValue);

            Assert.Equal(expectedValue, actualValue);
        }
    }
}