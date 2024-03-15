using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators;

public class NextLongBitsGenerator(IRandomGenerator randomGenerator) : IBooleanGenerator
{
    private const int BitsInByte = 8;
    private const int MaxBitIndex = sizeof(long) * BitsInByte;

    private long _randomLong;
    private int _currentBufferIndex = MaxBitIndex;

    public bool NextBool()
    {
        if (_currentBufferIndex >= MaxBitIndex)
        {
            _randomLong = randomGenerator.NextLong(long.MinValue, long.MaxValue);
            _currentBufferIndex = 0;
        }

        return (_randomLong & (1L << _currentBufferIndex++)) != 0;
    }
}
