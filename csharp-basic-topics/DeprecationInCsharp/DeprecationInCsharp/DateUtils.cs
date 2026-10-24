namespace DeprecationInCsharp;

public static class DateUtils
{
    [Obsolete($"Please use {nameof(GetCurrentYearV2)}() instead.",
        DiagnosticId = "DATEUTILS001",
        UrlFormat = "https://example.com/obsoletions/{0}")]
    public static int GetCurrentYearV1()
    {
        return 2022;
    }

    public static int GetCurrentYearV2()
    {
        return DateTime.UtcNow.Year;
    }
}