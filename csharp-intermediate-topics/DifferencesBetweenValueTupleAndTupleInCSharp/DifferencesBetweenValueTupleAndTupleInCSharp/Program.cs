// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Run();

public partial class Program
{
    public static void Run()
    {
        //This shows a chronological order of the code in the article, each method represents and holds all the code examples in a section of the article
        InitializationDifferences();
        StorageCapacity();
        AccessingMemberValues();
        ReturnAValueTuple();
        ReturnATuple();
        TakeInAValueTuple((4, true));
        TakeInATuple(Tuple.Create(6, false));
        Deconstruction();
        CheckingEqualityOfValueTuples();
        InterConversionOfTuples();
    }

    public static void InitializationDifferences()
    {
        (int, int) initializedValueTupleOne = (1, 2);

        var initializedValueTupleTwo = (1, 2);

        (int LastYear, int CurrentYear) namedValueTupleOne = (2021, 2022);
        var currentYear = namedValueTupleOne.CurrentYear;

        var rightHandNamedValueTuple = (language: "C#", tool: "Laptop", occupation: "Developer");

        (string lang, string machine, string career) rightHandNamedValueTupleTwo = (language: "C#", tool: "Laptop", occupation: "Developer");

        var initializedValueTupleFour = ValueTuple.Create("code-maze", "johndoe", "dotnet");

        var initializedTupleThree = Tuple.Create("code-maze", "johndoe", "dotnet");
        var valueTupleWithNoElementsOne = ValueTuple.Create();

        var valueTupleWithNoElements = new ValueTuple(); 
        var initializedValueTupleSix = new ValueTuple<decimal, decimal, decimal>(10000M, 20000M, 30000M);

    }
    public static void StorageCapacity()
    {
        var nestedTuple = Tuple.Create("my", "name", "is", "john", "doe", "and", "I", Tuple.Create("am", 1000, "years", "old", true));

        var valueTuple = ("my", "name", "is", "john", "doe", "and", "I", "am", 1000, "years", "old", true);

        var age = 999;
        var name = "metuse";
        var gender = "male";
        var occupation = "pilot";
        var hobby = "anime watching";
        var mail = "metuse11@mail.com";
        var bestColor = "blue";
        var weight = "1000kg";

        var profile = (age, name, gender, occupation, hobby, mail, bestColor, weight);
    }

    public static void AccessingMemberValues()
    {
        (string, string, int, bool) apiBook = ("codemaze", "Ultimate_ASP.NET_Core_Web_API_", 2021, false);
        var itemOne = apiBook.Item1; //returns "codemaze"
        var itemThree = apiBook.Item3; //returns 2021

        var evenNumbers = Tuple.Create(2, 4, 6, 8, 10, 12, 14,
        Tuple.Create(16, 18, 20, 22, 24, 26));

        var evenNumbersRestItem = evenNumbers.Rest.Item1; //returns (16, 18, 20, 22, 24, 26)
        var evenNumberRestItemElementOne = evenNumbers.Rest.Item1.Item1; //returns 16

        var evenNumbers2 = (one: 2, two: 4, three: 6, four: 8, five: 10, six: 12, seven: 14, eight: 16, nine: 18, ten: 20);
        var itemTwelve = evenNumbers2.nine; // returns 18
    }

    public static (bool isDay, string greeting) ReturnAValueTuple()
    {
        if (DateTime.Now.Hour < 12)
            return (isDay: true, greeting: "Good Morning");

        return (isDay: false, greeting: "Good Evening");
    }

    public static Tuple<bool, string> ReturnATuple()
    {
        if (DateTime.Now.Hour < 12)
            return Tuple.Create(true, "Good morning");

        return Tuple.Create(false, "Good Evening");
    }

    public static string TakeInAValueTuple((int legCount, bool isBlue) organism)
    {
        var hasAtLeastFourLegs = organism.legCount >= 4;
        var isBlue = organism.isBlue;

        return $"hasAtLeastFourLegs : {hasAtLeastFourLegs} and isBlue : {isBlue}";
    }

    public static string TakeInATuple(Tuple<int, bool> organism)
    {
        var hasAtLeastFourLegs = organism.Item1 >= 4;
        var isBlue = organism.Item2;

        return $"hasAtLeastFourLegs : {hasAtLeastFourLegs} and isBlue : {isBlue}";
    }
    public static void Deconstruction()
    {
        var result = CheckStringLength("October");
        var isLengthEven = result.isLengthEven; //returns false
        var message = result.message;// returns "this is odd"
        var stringLength = result.stringLength;//returns 7

        var (isLengthEvenn, messagee, stringLengthh) = CheckStringLength("October");

        var (_, message2, _) = CheckStringLength("January");
    }
    public static (bool isLengthEven, string message, int stringLength) CheckStringLength(string word)
    {
        var stringLength = word.Length;
        var isLengthEven = stringLength % 2 == 0;
        var message = isLengthEven ? "This is even" : "This is odd";

        return (isLengthEven, message, stringLength);
    }

    public static void MutabilityOfValueTuples()
    {
        (string satellite, string star, string planet, string galaxy) heavenlyBodies = ("satellite", "star", "planet", "galaxy");

        heavenlyBodies.planet = "earth";
        heavenlyBodies.galaxy = "milky way";
        heavenlyBodies.star = "antares";
        heavenlyBodies.satellite = "moon";
    }

    public static void CheckingEqualityOfValueTuples()
    {
        var valueTupleOne = (1, 3, 6);
        var valueTupleTwo = (2, 3, 7);

        var isEqual = valueTupleOne == valueTupleTwo;
        var isEqualTwo = (1, 3, 6) == (2, 3, 7);
    }

    public static void InterConversionOfTuples()
    {
        var tuple = new Tuple<int, string>(24, "john doe");
        var tupleConvertedToValueTuple = tuple.ToValueTuple();

        var valueTuple = (24, "john-doe");
        var valueTupleConvertedToTuple = valueTuple.ToTuple();
    }
}