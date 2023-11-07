namespace ActionFuncDelegatesInCSharp
{
    public class ActionDelegates
    {
        static void WriteProductToConsole(string product)
        {
            Console.Write(product + Environment.NewLine);
        }

        public static void CreateActionDelegates()
        {
            // With Action<string> return type 
            Action<string> writeMilkToConsole = WriteProductToConsole;
            writeMilkToConsole("Milk");

            // Assinging action delegate by using the new keyword
            Action<string> writeBreadToConsole = new Action<string>(WriteProductToConsole);
            writeBreadToConsole("Bread");

            // With anonymous delegate
            Action<string> writeCheeseToConsole = delegate (string product)
            {
                Console.Write(product + Environment.NewLine);
            };
            writeCheeseToConsole("Cheese");

            // With lambda expression
            Action<string> writeButterToConsole 
                = product => Console.Write(product + Environment.NewLine);
            writeButterToConsole("Butter");
        }
    }
}
