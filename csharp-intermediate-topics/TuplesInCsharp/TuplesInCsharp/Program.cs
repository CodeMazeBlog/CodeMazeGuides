// See https://aka.ms/new-console-template for more information
Console.WriteLine("Tuples in C#");

var tupleWithOneElement = new Tuple<string>("code-maze");

var tupleWithTwoElements = new Tuple<string, int>("code-maze", 24);

var tupleWithFiveElements = new Tuple<bool, int, string, decimal, string>(true, 3, "CSharp", 23M, "john-doe");

//CREATING TUPLES USING THE TUPLE.CREATE() METHOD
var tupleCreatedWithExplicitType = Tuple.Create<string>("code-maze"); 

var tupleCreatedWithNoExplicitType = Tuple.Create("code-maze"); 

var tupleWithEightElements = Tuple.Create(true, "between", "zero", "and", "one" , false, "bezao", 24);

var tupleContainingArrays = Tuple.Create(new int[] { 1, 2, 3 }, new string[] { "black", "white" });

var nestedTuple = Tuple.Create("my", "name", "is", "john", "doe", "and", "i", Tuple.Create("am", 1000, "years", "old", true));

//ACCESSING TUPLES
var itemOne = tupleWithEightElements.Item1; //returns true
var itemTwo = tupleWithEightElements.Item2; //returns 3 
var itemSeven = tupleWithEightElements.Item7; //return "bezao"
var itemEight = tupleWithEightElements.Rest; //returns (24)
var itemEightValue = tupleWithEightElements.Rest.Item1; //returns 24

//ACCESSING A NESTED TUPLE
var itemOneOfNestedTuple = nestedTuple.Rest.Item1.Item1; //returns "am"

var evenNumbers = Tuple.Create(2, 4, 6, 8, 10, 12, 14, Tuple.Create(16, 18, 20, 22, 24, 26));
var evenNumbersItemOne = evenNumbers.Item1; // returns 2
var evenNumbersItemSeven = evenNumbers.Item7; // returns 14
var restItem = evenNumbers.Rest.Item1; //returns (16, 18, 20, 22, 24, 26)
var restItemElementOne = evenNumbers.Rest.Item1.Item1; //returns 16
var RestItemElementTwo = evenNumbers.Rest.Item1.Item2; //returns 18

//CREATING A TUPLE WITH MULTIPLE NESTED TUPLES INSIDE IT
var multipleNestedTuple = Tuple.Create(Tuple.Create(2, 4, 6, 8, 10), Tuple.Create(1, 3, 5, 7, 9), Tuple.Create(4, 9, 16, 25, 36));
var multipleNestedTupleItemOne = multipleNestedTuple.Item1.Item1; //returns 2
var multipleNestedTupleItemTwo = multipleNestedTuple.Item2.Item1;//returns 1
var multipleNestedTupleItemThree = multipleNestedTuple.Item3.Item5;//returns 36

public partial class Program
{
    //METHOD THAT RETURNS A TUPLE
    public static Tuple<bool, string, int[]> ReturnATuple(int num)
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
    public static string TakeInATuple(Tuple<int, bool> tuple)
    {
        var hasAtLeastFourLegs = tuple.Item1 >= 4;
        var isBlue = tuple.Item2;

        return $"hasAtLeastFourLegs : {hasAtLeastFourLegs} and isBlue : {isBlue}";
    }

    public static void Run()
    {
        var methodAResult = ReturnATuple(24);

        var methodBResult = TakeInATuple(Tuple.Create(10, true));
    }
}