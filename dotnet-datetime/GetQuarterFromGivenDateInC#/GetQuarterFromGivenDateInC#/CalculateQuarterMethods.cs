namespace GetQuarterFromGivenDateInCSharp;

public static class CalculateQuarterMethods
{
    public static int CalculateQuarter(DateTime inputDate)
    {
        return (inputDate.Month + 2) / 3; ;
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
        return Enumerable.Range(1, 4).First(q => inputDate.Month <= q * 3);
    }

    public struct QuarterRange
    {
        public DateTime StartQuarterDate { get; set; }
        public DateTime EndQuarterDate { get; set; }

        public QuarterRange(DateTime startQuarterDate, DateTime endQuarterDate)
        {
            StartQuarterDate = startQuarterDate;
            EndQuarterDate = endQuarterDate;
        }
    }

    public static QuarterRange CalculateQuarterDates(DateTime inputDate)
    {
        var quarter = (int)Math.Ceiling(inputDate.Month / 3.0);
        var startQuarterMonth = (quarter - 1) * 3 + 1;
        var endQuarterMonth = startQuarterMonth + 2;
        var daysInMonth = DateTime.DaysInMonth(inputDate.Year, endQuarterMonth);
        var startQuarterDate = new DateTime(inputDate.Year, startQuarterMonth, 1);
        var endQuarterDate = new DateTime(inputDate.Year, endQuarterMonth, daysInMonth);

        return new QuarterRange (startQuarterDate, endQuarterDate);
    }

    public static int CalculateFiscalQuarterOffset(DateTime inputDate, DateTime fiscalYearStart)
    {
        var monthOffset = inputDate.Month - fiscalYearStart.Month;

        if (inputDate.Month == fiscalYearStart.Month
            && inputDate.Day < fiscalYearStart.Day
            || inputDate.Month < fiscalYearStart.Month)
        {
            monthOffset--;
        }

        monthOffset = (monthOffset + 12) % 12;
        var quarter = (monthOffset / 3) + 1;

        return quarter;
    }

    public static int CalculateFiscalQuarter(DateTime inputDate) 
    {
        return (int)Math.Ceiling(inputDate.Month / 3.0 + 2) % 4 + 1;
    }
}