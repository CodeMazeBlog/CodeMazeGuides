namespace ActionAndFuncDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Action delegates
            Action action = () => Console.WriteLine("Simplest Action Delegate");
            action();

            Action<int, float> testIntFloatActionDelegate;
            testIntFloatActionDelegate = (int num1, float num2) =>
            {
                var sum = num1 + num2;
                Console.WriteLine($"The sum is {sum}");
            };
            testIntFloatActionDelegate(10, 200.45f);

            //Func delegates
            Func<bool> func = () => false;
            Console.WriteLine(func());

            Func<float, float, float> testFloatFuncDelegate;
            testFloatFuncDelegate = (float a, float b) =>
            {
                return a / b;
            };
            Console.WriteLine(testFloatFuncDelegate(1000.25f, 24.25f));

            //Practical Example
            Func<Student, bool> studentFunc = (Student student) =>
            {
                return student.CGPA >= 8f;
            };

            StudentRepository.GetDistinctionStudents(studentFunc);
        }
    }
}