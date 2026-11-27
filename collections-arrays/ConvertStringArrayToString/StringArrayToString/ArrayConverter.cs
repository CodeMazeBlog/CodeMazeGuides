using System.Text;

namespace StringArrayToString;

public class ArrayConverter
{
    public string UsingLoopStringAdditionAssignment(string[] array)
    {
        var result = string.Empty;

        foreach (var item in array)
        {
            result += item;
        }

        return result;
    }

    public string UsingLoopStringBuilder(string[] array)
    {
        var result = new StringBuilder();

        foreach (var item in array)
        {
            result.Append(item);
        }

        return result.ToString();
    }

    public string UsingStringJoin(string[] array)
    {
        return string.Join(string.Empty, array);
    }

    public string UsingStringJoinWithSeparator(string[] array, string separator)
    {
        return string.Join(separator, array);
    }

    public string UsingStringConcat(string[] array)
    {
        return string.Concat(array);
    }

    public string UsingAggregation(string[] array)
    {
        return array.Aggregate((prev, current) => prev + current);
    }

    public string UsingAggregationWithStringBuilder(string[] array)
    {
        return array.Aggregate(new StringBuilder(), (prev, current) => prev.Append(current)).ToString();
    }
}
