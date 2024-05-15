using StaticAbstractMembersOnInterfaces.GenericMath;
using StaticAbstractMembersOnInterfaces.GenericMath.Money;
using StaticAbstractMembersOnInterfaces.StronglyTypedImplementation;

var firstUSDollarAmount = new USDollar(10.0);
var secondUSDollarAmount = new USDollar(8.2);

var firstCanadianDollarAmount = new CanadianDollar(10.0);
var secondCanadianDollarAmount = new CanadianDollar(8.2);

var usDollarAdditionResult = GenericCalculator.Add(firstCanadianDollarAmount, secondCanadianDollarAmount);
var usDollarSubtractionResult = GenericCalculator.Subtract(firstUSDollarAmount, secondUSDollarAmount);

var canadianDollarAdditionResult = GenericCalculator.Add(firstCanadianDollarAmount, secondCanadianDollarAmount);
var canadianDollarSubtractionResult = GenericCalculator.Subtract(firstCanadianDollarAmount, secondCanadianDollarAmount);

Console.WriteLine($"For US Dollar, addition result is {usDollarAdditionResult.Value}, subtraction result is {usDollarSubtractionResult.Value:f}");
Console.WriteLine($"For Canadian Dollar, addition result is {canadianDollarAdditionResult.Value}, subtraction result is {canadianDollarSubtractionResult.Value:f}");

var developerInstance = GenericEmployeeFactory.CreateEmployee<Developer>("John", "Doe");

Console.WriteLine($"Created a developer instance with firstName: {developerInstance.FirstName} and lastName: {developerInstance.LastName}");

var parsedDeveloperInstance = Developer.Parse("Jane,Doe", null);
Console.WriteLine($"Created a developer instance with firstName: {parsedDeveloperInstance.FirstName} and lastName: {parsedDeveloperInstance.LastName}");

bool isSuccessfullyParsed = Developer.TryParse("JohnDoe", null, out parsedDeveloperInstance);
Console.WriteLine($"Result of executing TryParse method is {isSuccessfullyParsed}");