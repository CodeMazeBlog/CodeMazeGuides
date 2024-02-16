using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators
{
    public class NextBytesGenerator(IRandomGenerator randomGenerator, int bufferLength) : IBooleanGenerator
    {
        private const int BitsInByte = 8;

        private readonly byte[] _buffer = new byte[bufferLength];

        private readonly int _maxBitIndex = bufferLength * BitsInByte;
        private int _currentBitIndex = bufferLength * BitsInByte;

        public bool NextBool()
        {
            if (_currentBitIndex >= _maxBitIndex)
            {
                randomGenerator.NextBytes(_buffer);
                _currentBitIndex = 0;
            }

            var currentByte = _buffer[_currentBitIndex / BitsInByte];
            var currentBit = _currentBitIndex++ % BitsInByte;

            return (currentByte & (1 << currentBit)) != 0;
        }
    }
}
