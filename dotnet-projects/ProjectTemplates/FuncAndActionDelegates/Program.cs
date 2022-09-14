

class Program 
{
    static void Main(string[] args){
   var number=3;
PrintNumbers(number);
MultiplyNumbers(number);
    }
public static void PrintNumbers(int number){
Console.WriteLine($"The number is {number}");
}
public static void MultiplyNumbers(int number){
    number *=2;
Console.WriteLine($"The multiply number is {number}");
}

}