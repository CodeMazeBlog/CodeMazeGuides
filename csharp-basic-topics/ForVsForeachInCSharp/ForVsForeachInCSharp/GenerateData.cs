using System.Collections;

namespace ForVsForeachInCSharp;

public static class GenerateData
{
    public static int[] GenerateArray(int size)
        => Enumerable.Range(0, size).ToArray();

    public static List<int> GenerateList(int size)
        => Enumerable.Range(0, size).ToList();

    public static ArrayList GenerateArrayList(int size)
    {
        var arrayList = new ArrayList(size);

        for (int i = 0; i < size; i++)
        {
            arrayList.Add(i);
        }

        return arrayList;
    }

    public static Dictionary<int, int> GenerateDictionary(int size)
        => Enumerable.Range(0, size).ToDictionary(k => k, v => v);
}