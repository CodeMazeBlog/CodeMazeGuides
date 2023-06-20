using BenchmarkDotNet.Attributes;

namespace HexToByteArray
{
    [MemoryDiagnoser]
    public class BenchmarkClass
    {
        private const string COLOR_GREEN = "FF008000"; // System.Drawing.Color.Green

        [Benchmark]
        public void FromHexString()
        {
            ConvertHex.FromHexString(COLOR_GREEN);
        }

        [Benchmark]
        public void FromHexWithCharacterWiseTranslation()
        {
            ConvertHex.FromHexWithCharacterWiseTranslation(COLOR_GREEN);
        }

        [Benchmark]
        public void FromHexWithPointers()
        {
            ConvertHex.FromHexWithPointers(COLOR_GREEN);
        }

        [Benchmark]
        public void FromHexWithSwitchComputation()
        {
            ConvertHex.FromHexWithSwitchComputation(COLOR_GREEN);
        }

        [Benchmark]
        public void FromHexWithBitFiddle()
        {
            ConvertHex.FromHexWithBitFiddle(COLOR_GREEN);
        }

        [Benchmark]
        public void FromHexWithLookup()
        {
            ConvertHex.FromHexWithLookup(COLOR_GREEN);
        }
    }
}
