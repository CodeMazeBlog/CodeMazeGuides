using System.Collections.Generic;

public class ActionFuncBase
{

    public static void PrintList(List<int> olist)
    {
        foreach (int item in olist)
        {
            Console.WriteLine(item);
        }

    }
    public static List<int> TripleList(List<int> tlist)
    {
        List<int> result = new List<int>();
        Triple(tlist, result);
        return result;

    }

    private static void Triple(List<int> tlist, List<int> result)
    {
        foreach (int item in tlist)
        {
            result.Add(3 * item);
        }
    }
}