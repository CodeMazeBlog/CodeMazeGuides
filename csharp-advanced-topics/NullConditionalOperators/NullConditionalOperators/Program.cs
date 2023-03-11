namespace NullConditionalOperators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var student = new Student("john", null);

            Console.WriteLine(student.Courses?[0]);
        }
    }
}