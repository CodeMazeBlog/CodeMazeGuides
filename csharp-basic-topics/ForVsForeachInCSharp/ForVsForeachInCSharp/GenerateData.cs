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
}
