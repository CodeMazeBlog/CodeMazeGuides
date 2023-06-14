using BenchmarkDotNet.Attributes;

namespace HexToByteArray
{
    [MemoryDiagnoser]
    public class BenchmarkClass
    {
        private const string COLOR_GREEN = "FF008000"; // System.Drawing.Color.Green

        [Benchmark]
        public void GetByteArray()
        {
            ConvertHex.FromHexString(COLOR_GREEN);
        }

        [Benchmark]
        public void GetByteArrayAlternateApproach()
        {
            ConvertHex.FromHexStringAlternative(COLOR_GREEN);
        }
    }
}
