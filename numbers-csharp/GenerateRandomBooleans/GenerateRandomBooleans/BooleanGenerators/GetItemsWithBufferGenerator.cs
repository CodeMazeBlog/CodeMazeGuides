using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators;

public class GetItemsWithBufferGenerator(IRandomGenerator randomGenerator, int bufferLength) : IBooleanGenerator
{
    private readonly bool[] _allPossibilities = [false, true];

    private int _currentBufferIndex = int.MaxValue;
    private bool[] _buffer = [];

    public bool NextBool()
    {
        if (_currentBufferIndex >= bufferLength)
        {
            _buffer = randomGenerator.GetItems<bool>(_allPossibilities, bufferLength);
            _currentBufferIndex = 0;
        }

        return _buffer[_currentBufferIndex++];
    }
}
