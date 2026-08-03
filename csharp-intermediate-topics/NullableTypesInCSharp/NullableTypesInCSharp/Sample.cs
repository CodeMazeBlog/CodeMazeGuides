public class Sample
{
    static int? number; //null by default    

    public static void Start()
    {
        Console.WriteLine(number.ToString()); //No compile-time error
    }

    public static (int comparisonOne, int comparisonTwo, int comparisonThree, int comparisonFour) Compare()
    {
        int? numberOne = 10; //null by default
        int? numberTwo = 12;

        var comparisonOne = Nullable.Compare(numberOne, numberTwo); //-1
        var comparisonTwo = Nullable.Compare(numberTwo, numberOne); // 1
        var comparisonThree =  Nullable.Compare(numberTwo, numberTwo); // 0

        bool? isRunning = null;
        bool? isDisposed = null;
        var comparisonFour = Nullable.Compare(isRunning, isDisposed);  //0

        return (comparisonOne, comparisonTwo, comparisonThree, comparisonFour);
    }
}
