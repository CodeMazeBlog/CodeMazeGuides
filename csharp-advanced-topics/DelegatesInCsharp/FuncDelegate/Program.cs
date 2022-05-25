namespace FuncDelegate
{
    class DoMath
    {
        public static double NumberTimesE(int i)
        {
            return i * Math.E;
        }
    }
    
    internal class Program
    {
        private delegate double NumberTransform(int i);
        
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            Func<int, bool> isGreatherThanFive = delegate(int i)
            {
                return i > 5;
            };

            var result = numbers
                .Where(isGreatherThanFive);

            foreach (var number in result)
            {
                Console.WriteLine(number);
            }

            NumberTransform transformer = DoMath.NumberTimesE;
            
            
            foreach (var number in numbers)
            {
                Console.WriteLine(transformer(number));
            }
        }
    }
}