namespace FuncDelegate
{
    public class FuncProgram
    {
        Func<int, int, int> sumDel = GetSum;

        public static int GetSum(int value1, int value2)
        {
            return value1 + value2;
        }

        public static void Main(string[] args)
        {
            var obj = new FuncProgram();

            var sum = obj.sumDel(10, 10);
            Console.WriteLine(sum);
        }
    }
}


