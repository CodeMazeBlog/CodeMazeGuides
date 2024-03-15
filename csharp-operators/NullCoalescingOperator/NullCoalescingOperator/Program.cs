using NullCoalescingOperator;

var incomeCalculator = new IncomeCalculator();

Console.WriteLine("Yearly income calculation");

var monthlyIncome = 1200;
var numberOfMonths = 10;
int? extraBonus = null;
var yearlyIncomeCalculated = incomeCalculator.CalculateYearlyIncome(monthlyIncome, numberOfMonths, extraBonus);
var extraBonusString = extraBonus?.ToString() ?? "NULL";
Console.WriteLine($"Monthly income: {monthlyIncome}, number of months: {numberOfMonths}, extra bonus: {extraBonusString}. \nYearly income: {yearlyIncomeCalculated}");

Console.WriteLine("\nMonthly income calculation");

var hourlyWage = 10;
int? numberOfHours = null;
var monthlyIncomeCalculated = incomeCalculator.CalculateMonthlyIncome(hourlyWage, null);
var numberOfHoursString = numberOfHours?.ToString() ?? "NULL";
Console.WriteLine($"Hourly wage: {hourlyWage}, number of hours: {numberOfHoursString}. \nMonthly income: {monthlyIncomeCalculated}");

Console.ReadLine();