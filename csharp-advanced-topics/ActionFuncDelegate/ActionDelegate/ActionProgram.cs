namespace ActionDelegate
{
    public class ActionProgram
    {

        Action<string, string> displayDel = DisplayMethod;
        //Action<string, string> displayDel = new Action<string, string>(DisplayMethod);
        public static void DisplayMethod(string firstName, string lastName)
        {
            Console.Write(firstName + " " + lastName);
        }

        public static void Main(string[] args)
        {
            var obj = new ActionProgram();
            obj.displayDel("John", "Abraham");

            Console.WriteLine();
           
        }
    }
}
