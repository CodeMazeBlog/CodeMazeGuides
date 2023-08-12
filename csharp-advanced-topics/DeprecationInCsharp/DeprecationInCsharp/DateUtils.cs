namespace DeprecationInCsharp;

public static class DateUtils
{
    [Obsolete("This method is deprecated. Use GetCurrentYearV2 instead", false)]
    public static int GetCurrentYearV1()
    {
        return 2022;
    }

    public static int GetCurrentYearV2()
    {
        return DateTime.UtcNow.Year;
    }
}