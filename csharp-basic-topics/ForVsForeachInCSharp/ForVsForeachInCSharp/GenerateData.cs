namespace ForVsForeachInCSharp;

public class GenerateData
{
    public int[] GenerateRandomArray(int size)
    {
        var array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = Random.Shared.Next();
        }

        return array;
    }

    public List<int> GenerateRandomList(int size)
    {
        var list = new List<int>(size);

        for (int i = 0; i < size; i++)
        {
            list.Add(Random.Shared.Next());
        }

        return list;
    }

    public Stack<int> GenerateRandomStack(int size)
    {
        var stack = new Stack<int>(size);

        for (int i = 0; i < size; i++)
        {
            stack.Push(Random.Shared.Next());
        }

        return stack;
    }

    public Queue<int> GenerateRandomQueue(int size)
    {
        var queue = new Queue<int>(size);

        for (int i = 0; i < size; i++)
        {
            queue.Enqueue(Random.Shared.Next());
        }

        return queue;
    }

    public Dictionary<int, int> GenerateRandomDictionary(int size)
    {
        var dictionary = new Dictionary<int, int>(size);

        for (int i = 0; i < size; i++)
        {
            dictionary.Add(i, Random.Shared.Next());
        }

        return dictionary;
    }
}