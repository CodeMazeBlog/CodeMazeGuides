namespace CommonMistakesInACsharpProgram
{
    partial class Application
    {
        public class DiscardStackTrace
        {
            public static void Main()
            {
                try
                {
                    Run();
                   // ThrowError();
                   // Sum(6, 8);
                }
                catch (Exception ex)
                {
                    throw ex;
                    //throw;
                }

            }

            public static int Sum(int numberOne, int numberTwo) => numberOne + numberTwo;

            public static void ThrowError() => throw new Exception("Custom Error");

            public static void Run()
            {
                Console.WriteLine();
                Sum(6, 8);
                Console.WriteLine($"{Environment.StackTrace}");


                /*
                 Result: 
                 at System.Environment.get_StackTrace()
                 at CommonMistakesInACsharpProgram.Application.DiscardStackTrace.Main() 
                 at Program.<Main>$(String[] args) 
                 */
            }
        }
    }
}
