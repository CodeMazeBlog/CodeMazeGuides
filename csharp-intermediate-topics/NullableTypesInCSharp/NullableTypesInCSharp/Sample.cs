// See https://aka.ms/new-console-template for more information
public class Sample
{
    int? number; //null by default    

    public void Start()
    {
        Console.WriteLine(number.ToString()); //No compile-time error
    }

    public static void Compare()
    {
        int? numberOne = 10; //null by default
        int? numberTwo = 12;

        Nullable.Compare(numberOne, numberTwo); //-1
        Nullable.Compare(numberTwo, numberOne); // 1
        Nullable.Compare(numberTwo, numberTwo); // 0

        bool? isRunning = null;
        bool? isDisposed = null;
        Nullable.Compare(isRunning, isDisposed);  //0

    }
}



