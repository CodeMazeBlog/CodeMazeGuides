using System.Runtime.InteropServices;

namespace RandomizeGenericListsInCSharp;

public class RandomizeGenericListsMethods
{
    private readonly Random _rand;

    public RandomizeGenericListsMethods() 
    {
        _rand = new Random();
    }

    public List<int> GenerateRandomLoop(List<int> listToShuffle)
    {
        for (int i = listToShuffle.Count - 1; i > 0; i--)
        {
            var k = _rand.Next(i + 1);
            var value = listToShuffle[k];
            listToShuffle[k] = listToShuffle[i];
            listToShuffle[i] = value;
        }

        return listToShuffle;
    }

    public List<int> GenerateRandomShuffle(List<int> listToShuffle)
    {
        _rand.Shuffle(CollectionsMarshal.AsSpan(listToShuffle));

        return listToShuffle;
    }

    public List<int> GenerateLinqShuffle(List<int> listToShuffle)
    {
        var shuffledList = listToShuffle.Shuffle().ToList();

        return shuffledList;
    }

    public List<int> GenerateRandomOrderBy(List<int> listToShuffle)
    {
        var shuffledList = listToShuffle.OrderBy(_ => _rand.Next()).ToList();

        return shuffledList;
    }

    public List<int> GenerateRandomOrderByGuid(List<int> listToShuffle)
    {
        var shuffledList = listToShuffle.OrderBy(_ => Guid.NewGuid()).ToList();

        return shuffledList;
    }

    // Don't do this: it picks k from the entire list, so some orders come up more often than others.
    public List<int> GenerateBiasedLoop(List<int> listToShuffle)
    {
        for (int i = listToShuffle.Count - 1; i >= 0; i--)
        {
            var k = _rand.Next(listToShuffle.Count);
            var value = listToShuffle[k];
            listToShuffle[k] = listToShuffle[i];
            listToShuffle[i] = value;
        }

        return listToShuffle;
    }

    public Dictionary<string, int> CountOrders(Func<List<int>, List<int>> shuffle, int runs)
    {
        var counts = new Dictionary<string, int>();

        for (int run = 0; run < runs; run++)
        {
            var order = string.Concat(shuffle([1, 2, 3]));
            counts[order] = counts.GetValueOrDefault(order) + 1;
        }

        return counts;
    }

    public List<int> OrderedInts(int size)
    {
        var numbers = new List<int>();

        for (int i = 0; i < size; i++)
        {
            numbers.Add(i);
        }

        return numbers;
    }
}
