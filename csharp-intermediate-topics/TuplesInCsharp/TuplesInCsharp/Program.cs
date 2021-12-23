// See https://aka.ms/new-console-template for more information
Console.WriteLine("Tuples in C#");

//CREATING TUPLES USING THE TUPLE CLASS CONSTRUCTOR!!

//Tuple with one member
var exampleOne = new Tuple<string>("code-maze");
//Tuple with two members
var exampleTwo = new Tuple<string, int>("code-maze", 24);
//Tuple with five members
var exampleThree = new Tuple<bool, int, string, decimal, string>(true, 3, "CSharp", 23M, "john-doe");

//CREATING TUPLES USING THE TUPLE.CREATE() METHOD
var example1 = Tuple.Create<string>("code-maze"); //With the specific type indicated
//var example1 = Tuple.Create("code-maze"); //Same code without type parameter

var example2 = Tuple.Create("code-maze", 24);

var example3 = Tuple.Create(true, 3, "code-maze", 23M, "blockchain");

//Tuple with eight members
var example4 = Tuple.Create(true, "between", "zero", "and", "one" , false, "bezao", 24);

//Tuple containing arrays
var example = new Tuple<int[], string[]>(new int[] { 1, 2, 3 }, new string[] { "black", "white" });

//CREATING A NESTED TUPLE
var nestedTuple = Tuple.Create("my", "name", "is", "john", "doe", "and", "i", Tuple.Create("am", 1000, "years", "old", true));

//ACCESSING TUPLES
var itemOne = example4.Item1; //returns true
var itemTwo = example4.Item2; //returns 3 
var itemSix = example4.Item7; //return "bezao"
var itemEight = example4.Rest; //returns (24)
var itemEgihtValue = example4.Rest.Item1; //returns 24

//ACCESSING A NESTED TUPLE
var nestedItemOne = nestedTuple.Rest.Item1.Item1; //returns "am"

var evenNumbers = Tuple.Create(2, 4, 6, 8, 10, 12, 14, Tuple.Create(16, 18, 20, 22, 24, 26));
var numOne = evenNumbers.Item1; // returns 2
var numTwo = evenNumbers.Item7; // returns 14
var numThree = evenNumbers.Rest.Item1; //returns (16, 18, 20, 22, 24, 26)
var numFour = evenNumbers.Rest.Item1.Item1; //returns 16
var numFive = evenNumbers.Rest.Item1.Item2; //returns 18

//CREATING A TUPLE WITH MULTIPLE NESTED TUPLES INSIDE IT
var multpleNestedTuple = Tuple.Create(Tuple.Create(2, 4, 6, 8, 10), Tuple.Create(1, 3, 5, 7, 9), Tuple.Create(4, 9, 16, 25, 36));
var stuff = multpleNestedTuple.Item1.Item1; //returns 2
var stuff2 = multpleNestedTuple.Item2.Item1;//returns 1
var stuff3 = multpleNestedTuple.Item3.Item5;//returns 36

public partial class Program 
{
    //METHOD THAT RETURNS A TUPLE
    public static Tuple<bool, string, int[]> MethodA(int num)
    {
        var isEven = num % 2 == 0;

        var message = isEven ? $"{num} This number is even" : $" {num}This number is odd";

        var multiplesOfNum = new int[5];

        for (var x = 1; x <= 5; x++)
        {
            multiplesOfNum.Append(x * num);
            Console.WriteLine(x * num);
        }

        return Tuple.Create(isEven, message, multiplesOfNum);
    }

    //METHOD THAT TAKES IN A TUPLE AS A PARAMETER
    public static string MethodB(Tuple<int, bool> tuple)
    {
        var hasAtLeastFourLegs = tuple.Item1 >= 4;
        var isBlue = tuple.Item2;

        return $"hasAtLeatFourLegs : {hasAtLeastFourLegs} and isBlue : {isBlue}";
    }
}



