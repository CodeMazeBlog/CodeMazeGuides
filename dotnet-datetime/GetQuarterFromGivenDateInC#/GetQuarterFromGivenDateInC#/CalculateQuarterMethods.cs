namespace GetQuarterFromGivenDateInCSharp;

public static class CalculateQuarterMethods
{
    public static int CalculateQuarter(DateTime inputDate)
    {
        return (int)Math.Ceiling(inputDate.Month / 3.0);
    }

    public static int CalculateQuarterUsingSelection(DateTime inputDate)
    {
        if (inputDate.Month <= 3)
        {
            return 1;
        }

        if (inputDate.Month <= 6)
        {
            return 2;
        }

        if (inputDate.Month <= 9)
        {
            return 3;
        }

        return 4;
    }

    public static int CalculateQuarterUsingArrayLookUp(DateTime inputDate)
    {
        int[] quarters = { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4 };

        return quarters[inputDate.Month - 1];
    }

    public static int CalculateQuarterUsingLinq(DateTime inputDate)
    {
        return Enumerable.Range(1, 12)
                         .Select(m => new { Month = m, Quarter = (m - 1) / 3 + 1 })
                         .Single(q => q.Month == inputDate.Month)
                         .Quarter;
    }

    public struct QuarterRange
    {
        public DateTime StartQuarterDate { get; set; }
        public DateTime EndQuarterDate { get; set; }
    }

    public static QuarterRange CalculateQuarterDates(DateTime inputDate)
    {
        var quarter = (int)Math.Ceiling(inputDate.Month / 3.0);
        var startQuarterMonth = (quarter - 1) * 3 + 1;
        var endQuarterMonth = startQuarterMonth + 2;
        var daysInMonth = DateTime.DaysInMonth(inputDate.Year, endQuarterMonth);
        var startQuarterDate = new DateTime(inputDate.Year, startQuarterMonth, 1);
        var endQuarterDate = new DateTime(inputDate.Year, endQuarterMonth, daysInMonth);

        return new QuarterRange { StartQuarterDate = startQuarterDate, EndQuarterDate = endQuarterDate };
    }

    public static int CalculateFiscalQuarterOffset(DateTime inputDate, DateTime fiscalYearStart)
    {
        var fiscalStartMonth = fiscalYearStart.Month;
        var fiscalYearStartDay = fiscalYearStart.Day;

        var year = inputDate.Year;
        var month = inputDate.Month;

        if (month < fiscalStartMonth || (month == fiscalStartMonth && inputDate.Day < fiscalYearStartDay))
        {
            year--;
        }

        var quarter = ((month - fiscalStartMonth + 3) % 12 + 1) / 3;

        return quarter;
    }

    public static int CalculateFiscalQuarter(DateTime inputDate) 
    {
        return (int)Math.Ceiling(inputDate.Month / 3.0 + 2) % 4 + 1;
    }
}