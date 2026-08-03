using System.Collections;

namespace Tests
{
    public class BitArrayInCSharpUnitTests
    {
        [Fact]
        public void WhenUsingConstructorInt32_ThenAllTheValuesAreFalse()
        {
            var bitArray = new BitArray(2);

            Assert.True(bitArray.Count == 2
                && bitArray[0] == false
                && bitArray[1] == false);
        }

        [Fact]
        public void WhenUsingConstructorInt32AndSpecifiedValue_ThenAllTheValuesSetToThisValue()
        {
            var bitArray = new BitArray(2, true);

            Assert.True(bitArray.Count == 2
                && bitArray[0] == true
                && bitArray[1] == true);
        }

        [Fact]
        public void WhenUsingConstructorArrayOfInt32_ThenEveryValueConvertsTo32Bits()
        {
            var bitArray = new BitArray(new int[2]);

            Assert.True(bitArray.Count == 32 * 2);
        }

        [Fact]
        public void WhenUsingConstructorArrayOfBytes_ThenEveryValueConvertsTo8Bits()
        {
            var bitArray = new BitArray(new byte[2]);

            Assert.True(bitArray.Count == 8 * 2);
        }

        [Fact]
        public void WhenUsingConstructorArrayOfBooleans_ThenEveryValueConvertsTo1Bit()
        {
            var bitArray = new BitArray(new bool[2]);

            Assert.True(bitArray.Count == 1 * 2);
        }

        [Fact]
        public void WhenUsingConstructorBitArray_ThenTheValuesCopyToCurrentObject()
        {
            var bitArray = new BitArray(new BitArray(2));

            Assert.True(bitArray.Count == 2
                && bitArray[0] == false
                && bitArray[1] == false);
        }

        [Fact]
        public void WhenUsingIsReadOnlyProperty_ThenReturnsAlwaysFalse()
        {
            var bitArray = new BitArray(2);

            Assert.False(bitArray.IsReadOnly);
        }

        [Fact]
        public void WhenUsingIsSynchronizedProperty_ThenReturnsAlwaysFalse()
        {
            BitArray bitArray = new BitArray(2);

            Assert.False(bitArray.IsSynchronized);
        }

        [Fact]
        public void WhenUsingIndexOutOfRange_ThenThrowsAlwaysArgumentOutOfRangeException()
        {
            BitArray bitArray = new BitArray(2);

            Assert.Throws<ArgumentOutOfRangeException>(() => bitArray[3]);
        }

        [Fact]
        public void WhenUsingLengthProperty_ThenItEqualsCount()
        {
            BitArray bitArray = new BitArray(2);

            Assert.Equal(bitArray.Count, bitArray.Length);
        }

        [Fact]
        public void WhenUsingGetMethod_ThenItEqualsUsesIndexer()
        {
            BitArray bitArray = new BitArray(2);

            Assert.Equal(bitArray.Get(0), bitArray[0]);
        }

        [Fact]
        public void WhenUsingSetMethod_ThenTheValuesSetsToSpecifiedValue()
        {
            BitArray bitArray = new BitArray(2);
            bitArray.Set(0, true);

            Assert.True(bitArray.Get(0));
        }

        [Fact]
        public void WhenUsingSetAllMethod_ThenAllValuesSetsToSpecifiedValue()
        {
            BitArray bitArray = new BitArray(2);
            bitArray.SetAll(true);

            Assert.True(bitArray.Count == 2
                && bitArray[0] == true
                && bitArray[1] == true);
        }

        [Fact]
        public void WhenUsingAndMethod_ThenTheCurrentObjectIsModefied()
        {
            BitArray bitArray1 = new BitArray(new bool[] { false, false, true, true }); 
            BitArray bitArray2 = new BitArray(new bool[] { false, true, true, false });

            bitArray1.And(bitArray2);

            Assert.True(bitArray1[0] == false
                && bitArray1[1] == false
                && bitArray1[2] == true
                && bitArray1[3] == false);
        }

        [Fact]
        public void WhenUsingOrMethod_ThenTheCurrentObjectIsModefied()
        {
            BitArray bitArray1 = new BitArray(new bool[] { false, false, true, true });
            BitArray bitArray2 = new BitArray(new bool[] { false, true, true, false });

            bitArray1.Or(bitArray2);

            Assert.True(bitArray1[0] == false
                && bitArray1[1] == true
                && bitArray1[2] == true
                && bitArray1[3] == true);
        }

        [Fact]
        public void WhenUsingXorMethod_ThenTheCurrentObjectIsModefied()
        {
            BitArray bitArray1 = new BitArray(new bool[] { false, false, true, true });
            BitArray bitArray2 = new BitArray(new bool[] { false, true, true, false });

            bitArray1.Xor(bitArray2);

            Assert.True(bitArray1[0] == false
                && bitArray1[1] == true
                && bitArray1[2] == false
                && bitArray1[3] == true);
        }
    }
}