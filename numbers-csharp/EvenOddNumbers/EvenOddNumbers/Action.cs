namespace Delegates
{
public class ActionDelegate
{
    public static void IsEvenNum(int number) => Console.WriteLine(number % 2 == 0);
    public void EvenNumber(int number)
    {
        //Action even = () => IsEvenNum(4);
        Action even = () => Console.WriteLine(number % 2 == 0);
        even();

    }
}

}
