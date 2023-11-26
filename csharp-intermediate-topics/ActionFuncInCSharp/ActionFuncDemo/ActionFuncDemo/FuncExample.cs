namespace ActionFuncDemo;

public class FuncExample
{
    public static int CalculateAgeInTenYears(int x)
    {
        Func<int, int> CalculateAgeInTenYearsFuncDelegate = x => { return x + 10; };

        return CalculateAgeInTenYearsFuncDelegate(x);
    }
}