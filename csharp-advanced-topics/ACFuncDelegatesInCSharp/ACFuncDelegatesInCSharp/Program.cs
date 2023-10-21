namespace ACFuncDelegatesInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                Console.WriteLine("********************************");
                Console.WriteLine(" Action and Func Delegates in C# ");
                Console.WriteLine("*********************************");

                MyCustomerPresentation mycustomerPresentation = new MyCustomerPresentation();
                mycustomerPresentation.CheckUpdate();
            
        }
    }
}