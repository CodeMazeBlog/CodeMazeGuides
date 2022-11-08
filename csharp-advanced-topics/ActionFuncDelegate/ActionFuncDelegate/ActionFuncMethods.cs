
namespace ActionFuncDelegate
{
    public class ActionFuncMethods
    {
        //Methods that accept parameters but doesn't return value

        public static void DisplayMsg()
        {
            Console.WriteLine("Welcome to Action and Func delegates");
        }

        public static void DisplayNumbers(int num, int total)
        {
            for (var i = num; i <= total; i++)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine();
        }

        public static void Display(string msg)
        {
            Console.WriteLine(msg);
        }

        //Methods that accept parameters and returns a value

        public static int Add(int i, int j)
        {
            return i + j;
        }

        public static string ShowAddition(int i, int j)
        {
            return string.Format("Sum of {0} and {1} is {2}", i, j, i + j);
        }

        public static string FullName(string firstname, string lastname)
        {
            return string.Format("Full Name is {0} {1}", firstname, lastname);
        }

        public static int DisplayNum()
        {
            Random r = new Random();

            return r.Next();
        }
    }
}
