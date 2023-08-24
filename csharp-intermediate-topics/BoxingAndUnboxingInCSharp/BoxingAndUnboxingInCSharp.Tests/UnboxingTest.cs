using BoxingAndUnboxingInCSharp;

namespace BoxingAndUnboxing.Test
{
    public class UnboxingTest
    {
        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToInt_ThenExecuteUnboxing()
        {
            int expectedValue = int.MinValue;
            int actualValue = Conversion.UnboxToInt(-2147483648);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToSByte_ThenExecuteUnboxing()
        {
            object value = sbyte.MinValue;
            sbyte expectedValue = sbyte.MinValue;
            sbyte actualValue = Conversion.UnboxToSbyte(value);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToByte_ThenExecuteUnboxing()
        {
            object value = byte.MaxValue;
            byte expectedValue = byte.MaxValue;
            byte actualValue = Conversion.UnboxToByte(value);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToNint_ThenExecuteUnboxing()
        {
            object value = (nint)125;
            nint expectedValue = 125;
            nint actualValue = Conversion.UnboxToNint(value);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToNuint_ThenExecuteUnboxing()
        {
            object value = (nuint)125;
            nuint expectedValue = 125;
            nuint actualValue = Conversion.UnboxToNuint(value);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToUint_ThenExecuteUnboxing()
        {
            uint expectedValue = uint.MaxValue;
            uint actualValue = Conversion.UnboxToUint(4294967295);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToUShort_ThenExecuteUnboxing()
        {
            object value = ushort.MaxValue;
            ushort expectedValue = ushort.MaxValue;
            ushort actualValue = Conversion.UnboxToUshort(value);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToLong_ThenExecuteUnboxing()
        {
            object value = -9223372036854775808;
            long expectedValue = long.MinValue;
            long actualValue = Conversion.UnboxToLong(value);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToULong_ThenExecuteUnboxing()
        {
            ulong expectedValue = ulong.MaxValue;
            ulong actualValue = Conversion.UnboxToUlong(18446744073709551615);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToDouble_ThenExecuteUnboxing()
        {
            double expectedValue = double.MinValue;
            double actualValue = Conversion.UnboxToDouble(-1.7976931348623157E+308D);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToDecimal_ThenExecuteUnboxing()
        {
            decimal expectedValue = decimal.MinValue;
            decimal actualValue = Conversion.UnboxToDecimal(-79228162514264337593543950335m);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToFloat_ThenExecuteUnboxing()
        {
            float expectedValue = float.MinValue;
            float actualValue = Conversion.UnboxToFloat(-3.40282347E+38f);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToShort_ThenExecuteUnboxing()
        {
            object value = short.MinValue;
            short expectedValue = short.MinValue;
            short actualValue = Conversion.UnboxToShort(value);

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GivenAnObjectValue_WhenTryToUnboxToChar_ThenExecuteUnboxing()
        {
            object value = char.MaxValue;
            char expectedValue = char.MaxValue;
            char actualValue = Conversion.UnboxToChar(value);

            Assert.Equal(expectedValue, actualValue);
        }

    }
}