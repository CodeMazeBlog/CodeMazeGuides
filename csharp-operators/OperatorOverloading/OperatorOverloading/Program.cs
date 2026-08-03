
namespace OperatorOverloading
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //unary operator overloading
            var john = new Student(1, 1, "John", 7, 2);
            john++;
            Console.WriteLine($"{john.GetName()} has passed {john.GetNumberOfPassedCourses()} courses.");
            Console.WriteLine();

            //Binary operator overloading
            var alice = new Student(1, 5, "Alice", 12, 5);
            Console.WriteLine(john > alice ? $"{john.GetName()} is older than {alice.GetName()}." : $"{john.GetName()} is younger than {alice.GetName()}.");
            Console.WriteLine();

            //Override Equals method
            var johnSecond = new Student(1, 1, "John", 7, 2);
            Console.WriteLine(john.Equals(johnSecond) ? "Both indicate the same person." : "They indicate different persons.");
            Console.WriteLine(john == johnSecond ? "Both indicate the same person." : "They indicate different persons.");
            Console.WriteLine();

            //== operator overloading
            johnSecond++;
            Console.WriteLine(john.Equals(johnSecond) ? "Both indicate the same person." : "They indicate different persons.");
            Console.WriteLine(john == johnSecond ? "Both indicate the same person." : "They indicate different persons.");
            Console.WriteLine();

            //!= operator overloading
            Console.WriteLine(john != alice ? "They indicate different persons." : "Both indicate the same person.");
        }
    }
}