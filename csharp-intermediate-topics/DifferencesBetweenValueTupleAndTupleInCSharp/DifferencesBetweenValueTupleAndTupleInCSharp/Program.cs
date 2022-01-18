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

        var rightHandNamedValueTuple = (Language: "C#", Tool: "Laptop", Occupation: "Developer");

        (string lang, string machine, string career) rightHandNamedValueTupleTwo = (Language: "C#", Tool: "Laptop", Occupation: "Developer");

        var initializedValueTupleFour = ValueTuple.Create("code-maze", "johndoe", "dotnet");

        var initializedTupleThree = Tuple.Create("code-maze", "johndoe", "dotnet");
        var valueTupleWithNoElementsOne = ValueTuple.Create();

        var valueTupleWithNoElements = new ValueTuple(); //creating valueTuple with no elements
        var initializedValueTupleSix = new ValueTuple<decimal, decimal, decimal>(10000M, 20000M, 30000m);

    }
    public static void StorageCapacity()
    {
        var nestedTuple = Tuple.Create("my", "name", "is", "john", "doe", "and", "I", Tuple.Create("am", 1000, "years", "old", true));

        var valueTuple = ("my", "name", "is", "john", "doe", "and", "I", "am", 1000, "years", "old", true);

        var age = 999;
        var name = "Metuse";
        var gender = "male";
        var occupation = "pilot";
        var hobby = "Anime watching";
        var mail = "metuse11@mail.com";
        var bestColor = "blue";
        var weight = "1000kg";

        var profile = (age, name, gender, occupation, hobby, mail, bestColor, weight);
    }

    public static void AccessingMemberValues()
    {
        (string, string, int, bool) ApiBook = ("codemaze", "Ultimate_ASP.NET_Core_Web_API_", 2021, false);
        var itemOne = ApiBook.Item1; //returns "codemaze"
        var itemThree = ApiBook.Item3; //returns 2021

        var vowels = Tuple.Create("a", "e", "i", "o", "u");
        var fourthVowel = vowels.Item4; //returns "o"

        (string author, string booktitle, int publishYear, bool isFiction) ApiBookTwo = ("codemaze", "Ultimate_ASP.NET_Core_Web_API_", 2021, false);

        var author = ApiBookTwo.author; //returns "codemaze
        var publishYear = ApiBookTwo.publishYear; //returns 2021

        var evenNumbers = Tuple.Create(2, 4, 6, 8, 10, 12, 14,
        Tuple.Create(16, 18, 20, 22, 24, 26));

        var evenNumbersRestItem = evenNumbers.Rest.Item1; //returns (16, 18, 20, 22, 24, 26)
        var evenNumberRestItemElementOne = evenNumbers.Rest.Item1.Item1; //returns 16

        var evenNumbers2 = (one: 2, two: 4, three: 6, four: 8, five: 10, six: 12, seven: 14, eight: 16, nine: 18, ten: 20);
        var itemTwelve = evenNumbers2.nine; // returns 18
    }

    public static (bool isDay, string Greeting) ReturnAValueTuple()
    {
        if (DateTime.Now.Hour < 12)
            return (isDay: true, Greeting: "Good Morning");

        return (isDay: false, Greeting: "Good Evening");
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
        var isLengthEven = result.isLengthEven;
        var message = result.message;
        var stringLength = result.stringLength;

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
        (string satellite, string star, string planet, string galaxy) heavenlybodies = ("satellite", "star", "planet", "galaxy");

        heavenlybodies.planet = "Earth";
        heavenlybodies.galaxy = "Milky way";
        heavenlybodies.star = "Antares";
        heavenlybodies.satellite = "moon";
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