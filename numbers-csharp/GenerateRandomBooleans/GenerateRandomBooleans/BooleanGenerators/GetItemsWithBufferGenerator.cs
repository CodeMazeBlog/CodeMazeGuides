using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators;

public class GetItemsWithBufferGenerator(IRandomGenerator randomGenerator, int bufferLength) : IBooleanGenerator
{
    private static readonly bool[] _allPossibilities = [false, true];
    private readonly bool[] _buffer = new bool[bufferLength];

    private int _currentBufferIndex = bufferLength;

    public bool NextBool()
    {
        if (_currentBufferIndex >= _buffer.Length)
        {
            randomGenerator.GetItems<bool>(_allPossibilities, _buffer);
            _currentBufferIndex = 0;
        }

        return _buffer[_currentBufferIndex++];
    }
}