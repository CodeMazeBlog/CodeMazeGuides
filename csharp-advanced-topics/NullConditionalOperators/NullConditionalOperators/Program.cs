namespace NullConditionalOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student? student = null;

            Console.WriteLine($"Student name is: {student?.Name}");
            Console.WriteLine($"First enrolled course is: {student?.Courses?[2]}");

            var name = student?.Name ?? "John";

            Student namelessStudent = new Student(null, null);
            namelessStudent.Name ??= "John";

            student?.Enroll("Math");
        }
    }
}