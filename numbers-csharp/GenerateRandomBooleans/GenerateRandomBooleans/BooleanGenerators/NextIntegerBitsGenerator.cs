using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators
{
    public class NextIntegerBitsGenerator(IRandomGenerator randomGenerator) : IBooleanGenerator
    {
        public const int BitsInByte = 8;
        public const int MaxBitIndex = sizeof(int) * BitsInByte;

        private readonly IRandomGenerator _randomGenerator = randomGenerator;

        private int _randomInteger;
        private int _currentBufferIndex = MaxBitIndex;

        public bool NextBool()
        {
            if (_currentBufferIndex >= MaxBitIndex)
            {
                _randomInteger = _randomGenerator.NextInteger(int.MinValue, int.MaxValue);
                _currentBufferIndex = 0;
            }

            return (_randomInteger & (1 << _currentBufferIndex++)) != 0;
        }
    }
}
