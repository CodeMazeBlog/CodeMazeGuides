using EqualityOperatorVsEqualsMethodInCSharp.Classes;
using EqualityOperatorVsEqualsMethodInCSharp.Records;
using EqualityOperatorVsEqualsMethodInCSharp.Structs;

namespace EqualityOperatorVsEqualsMethodInCSharp
{
    public class Program
    {
        static void Main()
        {
            ComparisonBetweenIntegers();
            ComparisonBetweenObjects();
            ComparisonBetweenStrings();
            ComparisonBetweenObjectAndString();
            ComparisonBetweenClasses();
            ComparisonBetweenStructs();
            ComparisonBetweenRecords();
            ComparisonBetweenNullables();
        }

        public static string ComparisonBetweenIntegers()
        {
            int firstNumber = 5;
            int secondNumber = 5;

            return PrintFormattedResult(
                ReferenceEquals(firstNumber, secondNumber), // false
                firstNumber == secondNumber, // true
                firstNumber.Equals(secondNumber) // true
            );
        }

        public static string ComparisonBetweenObjects()
        {
            object firstObject = new[] { 1, 2, 3 };
            object secondObject = new[] { 1, 2, 3 };

            return PrintFormattedResult(
                ReferenceEquals(firstObject, secondObject), // false
                firstObject == secondObject, // false
                firstObject.Equals(secondObject) // false
            );
        }

        public static string ComparisonBetweenStrings()
        {
            string firstWord = "pqr";
            string secondWord = "pqr";

            return PrintFormattedResult(
                ReferenceEquals(firstWord, secondWord), // true
                firstWord == secondWord, // true
                firstWord.Equals(secondWord) // true
            );
        }

        public static string ComparisonBetweenObjectAndString()
        {
            object thirdObject = new string(new[] { 'x', 'y', 'z' });
            string thirdWord = "xyz";

            return PrintFormattedResult(
                ReferenceEquals(thirdObject, thirdWord), // false
                thirdObject == thirdWord, // false
                thirdObject.Equals(thirdWord) // true
            );
        }

        public static string ComparisonBetweenClasses()
        {
            var firstEmployee = new Employee("Hermione Granger", 5000);
            var secondEmployee = new Employee("Hermione Granger", 5000);

            return PrintFormattedResult(
                ReferenceEquals(firstEmployee, secondEmployee), // false
                firstEmployee == secondEmployee, // false
                firstEmployee.Equals(secondEmployee) // false
            );
        }

        public static string ComparisonBetweenStructs()
        {
            var firstCar = new Car("Audi R8", 3715);
            var secondCar = new Car("Audi R8", 3715);

            return PrintFormattedResult(
                ReferenceEquals(firstCar, secondCar), // false
                firstCar == secondCar, // true
                firstCar.Equals(secondCar) // true
            );
        }

        public static string ComparisonBetweenRecords()
        {
            var firstLaptop = new Laptop("ASUS TUF A15", 1499);
            var secondLaptop = new Laptop("ASUS TUF A15", 1499);

            return PrintFormattedResult(
                ReferenceEquals(firstLaptop, secondLaptop), // false
                firstLaptop == secondLaptop, // true
                firstLaptop.Equals(secondLaptop) // true
            );
        }

        public static string ComparisonBetweenNullables()
        {
            int? firstNullableNumber = null;
            int? secondNullableNumber = null;

            return PrintFormattedResult(
                ReferenceEquals(firstNullableNumber, secondNullableNumber), // true
                firstNullableNumber == secondNullableNumber, // true
                firstNullableNumber.Equals(secondNullableNumber) // true
            );
        }

        public static string PrintFormattedResult(bool? a, bool? b, bool? c)
        {
            var result = $"Reference: {a}, Equality: {b}, Equals: {c}";
            Console.WriteLine(result);

            return result;
        }
    }
}