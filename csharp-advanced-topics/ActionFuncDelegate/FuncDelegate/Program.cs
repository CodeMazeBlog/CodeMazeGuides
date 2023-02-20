namespace FuncDelegate
{
    public class Program
    {
        public delegate void Display(string firstName, string lastName);
        Func<int,int,int> sumDel = GetSum;

        public static int GetSum(int value1, int value2)
        {
            return value1 + value2;
        }


        public static void Main(string[] args)
        {
            var obj = new Program();
         
            var sum = obj.sumDel(10, 10);
            Console.WriteLine(sum);
        }
    }
}


