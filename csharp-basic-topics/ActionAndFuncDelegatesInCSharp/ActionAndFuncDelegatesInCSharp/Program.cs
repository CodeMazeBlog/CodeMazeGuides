namespace ActionAndFuncDelegatesInCSharp
{
    public class Program
    {
        public delegate void DelegateMethod(); 

        static void Main(string[] args) 
        { 
            // Delegates
            DelegateMethod del1 = DelegateMethodsExample.Show; 
            DelegateMethod del2 = new DelegateMethod(DelegateMethodsExample.Display); 
            DelegateMethodsExample obj = new DelegateMethodsExample(); 
            DelegateMethod del3 = obj.Print; 

            del1(); 
            del2(); 
            del3();


            //Action Delegates
            Action<int> printActionDel = ActionDelegate.ConsolePrint;
            printActionDel(10);

            Func<int, int, int> add = FuncDelegate.Sum; 
            int result = add(10, 10);
            Console.WriteLine($"Func Delegate: Return Value is {result}");

            Console.ReadLine(); 
        }
    }

    public class DelegateMethodsExample
    {
        public static void Display()
        {
            Console.WriteLine("Hello from delegate");
        }

        public static void Show()
        {
            Console.WriteLine("Hi delegate");
        }

        public void Print()
        {
            Console.WriteLine("Print delegate");
        }
    }
}
