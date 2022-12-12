namespace ToStringMethod;

public static class StringExtensions
{
    public static string ConvertNullObjectToString(this object obj)
    {
        return obj.ToString();
    }

    public static string HandleNullException(this object obj)
    {
        var result = string.Empty;

        if (obj != null)
            result = obj.ToString();

        return result;
    }
}