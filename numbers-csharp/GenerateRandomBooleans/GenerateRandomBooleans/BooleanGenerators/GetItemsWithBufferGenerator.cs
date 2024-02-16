using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators;

public class GetItemsWithBufferGenerator : IBooleanGenerator
{
    private static readonly bool[] _allPossibilities = [false, true];
    private readonly bool[] _buffer;

    private readonly IRandomGenerator _randomGenerator;
    private int _currentBufferIndex;

    public GetItemsWithBufferGenerator(IRandomGenerator randomGenerator, int bufferLength)
    {
        _randomGenerator = randomGenerator;

        _buffer = new bool[bufferLength];
        _currentBufferIndex = bufferLength;
    }

    public bool NextBool()
    {
        if (_currentBufferIndex >= _buffer.Length)
        {
            _randomGenerator.GetItems<bool>(_allPossibilities, _buffer);
            _currentBufferIndex = 0;
        }

        return _buffer[_currentBufferIndex++];
    }
}