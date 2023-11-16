namespace NullCoalescingOperator
{
    public class IncomeCalculator
    {
        public int CalculateYearlyIncome(int monthlyIncome, int numberOfMonths, int? extraBonus = null)
        {
            return monthlyIncome * numberOfMonths + (extraBonus ?? 0);
        }

        public int CalculateMonthlyIncome(int? hourlyWage, int? numberOfHours)
        {
            hourlyWage = hourlyWage ?? throw new ArgumentNullException(nameof(hourlyWage), $"Null value is not allowed");
            numberOfHours ??= 168;

            return hourlyWage.Value * numberOfHours.Value;
        }
    }
}
