using BenchmarkDotNet.Attributes;

namespace HexToByteArray
{
    [MemoryDiagnoser]
    public class BenchmarkClass
    {
        private readonly ConvertHex _convertHex = new ConvertHex();
        private const string COLOR_GREEN = "FF008000"; // System.Drawing.Color.Green

        [Benchmark]
        public void GetByteArray()
        {
            _convertHex.FromHexString(COLOR_GREEN);
        }

        [Benchmark]
        public void GetByteArrayAlternateApproach()
        {
            _convertHex.FromHexStringAlternative(COLOR_GREEN);
        }
    }
}
