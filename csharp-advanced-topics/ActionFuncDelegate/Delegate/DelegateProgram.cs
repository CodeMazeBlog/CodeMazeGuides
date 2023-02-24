namespace Delegate
{
    public class DelegateProgram
    {
        public delegate void Display(string firstName, string lastName);
        public delegate int Sum(int value1, int value2);

        Display displayDel = DisplayMethod;
        Sum sumDel = GetSum;

        public static void DisplayMethod(string firstName, string lastName)
        {
            Console.Write(firstName + " " + lastName);
        }
        public static int GetSum(int value1, int value2)
        {
            return value1 + value2;
        }

        public static void Main(string[] args)
        {
            var obj = new DelegateProgram();
            obj.displayDel("John", "Abraham");

            Console.WriteLine();

            var sum = obj.sumDel(10, 10);
            Console.WriteLine(sum);
        }
    }
}