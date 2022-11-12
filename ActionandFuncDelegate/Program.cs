class Program
{
    static void Main(string[] args)
    {
        Action dispText = new Action(ActionDelegate.displayText);
        Action<string> dispname = new Action<string>(ActionDelegate.displayName);
        Action<int, int> dispProduct = new Action<int, int>(ActionDelegate.product);

        Func<int, int,int> sum1 = new Func<int, int, int>(FuncDelegate.sum);
        Func<int, int, string> sum2 = new Func<int, int, string>(FuncDelegate.displaySum);
        Func<int> random = new Func<int>(FuncDelegate.randomNumber);

        //Action Delegate
         dispText();    //Parameter: 0 , Returns: nothing
         dispname("Code-Maze");  //Parameter: 1 , Returns: nothing
         dispProduct(50, 20); //Parameter: 2 , Returns: nothing
        


        //Func Delegate
        int addition1= sum1(1,1);  //Parameter: 2 , Returns: int
        string addition2 = sum2(20,30);  //Parameter: 2 , Returns: string
        int randomNumbers = random();   ////Parameter: 0 , Returns: int

        Console.WriteLine("Addition: {0}",addition1);
        Console.WriteLine(addition2);
        Console.WriteLine("Random Number is: {0}",randomNumbers);

    }
}
