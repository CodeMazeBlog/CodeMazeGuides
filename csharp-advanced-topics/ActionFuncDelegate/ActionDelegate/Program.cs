namespace ActionDelegate
{
    public class Program
    {

        Action<string, string> displayDel = DisplayMethod;
        //Action<string, string> displayDel = new Action<string, string>(DisplayMethod);
        public static void DisplayMethod(string firstName, string lastName)
        {
            Console.WriteLine(firstName + " " + lastName);
        }

        public static void Main(string[] args)
        {
            var obj = new Program();
            obj.displayDel("John", "Abraham");

            Console.WriteLine();
           
        }
    }
}
