using System.Collections;

namespace ForVsForeachInCSharp;

public class GenerateData
{
    public static int[] GenerateRandomArray(int size)
    {
        var array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = i;
        }

        return array;
    }

    public static List<int> GenerateRandomList(int size)
    {
        var list = new List<int>(size);

        for (int i = 0; i < size; i++)
        {
            list.Add(i);
        }

        return list;
    }

    public static ArrayList GenerateRandomArrayList(int size)
    {
        var arrayList = new ArrayList(size);

        for (int i = 0; i < size; i++)
        {
            arrayList.Add(i);
        }

        return arrayList;
    }

    public static Dictionary<int, int> GenerateRandomDictionary(int size)
    {
        var dictionary = new Dictionary<int, int>(size);

        for (int i = 0; i < size; i++)
        {
            dictionary.Add(i, i);
        }

        return dictionary;
    }
}