using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GetQuarterFromGivenDateInCSharp;

public static class CalculateQuarterMethods
{
    public static double CalculateQuarter(DateTime inputDate)
    {
        return Math.Ceiling(inputDate.Month / 3.0);
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
}
