using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators
{
    public class NextIntegerBitsGenerator(IRandomGenerator randomGenerator) : IBooleanGenerator
    {
        private const int BitsInByte = 8;
        private const int MaxBitIndex = sizeof(int) * BitsInByte;

        private int _randomInteger;
        private int _currentBufferIndex = MaxBitIndex;

        public bool NextBool()
        {
            if (_currentBufferIndex >= MaxBitIndex)
            {
                _randomInteger = randomGenerator.NextInteger(int.MinValue, int.MaxValue);
                _currentBufferIndex = 0;
            }

            return (_randomInteger & (1 << _currentBufferIndex++)) != 0;
        }
    }
}
