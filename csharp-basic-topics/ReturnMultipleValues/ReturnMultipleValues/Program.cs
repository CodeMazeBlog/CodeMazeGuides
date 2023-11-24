using ReturnMultipleValues;

Console.WriteLine("Return Multiple Values to a Method Caller in C#");

UsingTuple();
UsingTupleDestructuring();
Console.WriteLine("---");

UsingTupleLiterals();
Console.WriteLine("---");

UsingOutKeyword();
Console.WriteLine("---");

UsingObjectInstance();
Console.WriteLine("---");

UsingDictionary();
Console.WriteLine("---");

UsingArrayOfObject();
Console.WriteLine("---");

void UsingTuple()
{
    Console.WriteLine(" Using Tuple:");

    var tuple = MultipleValuesReturner.GetValuesUsingTuple();

    Console.WriteLine(tuple.Item1);
    Console.WriteLine(tuple.Item2);
    Console.WriteLine(tuple.Item3);

    Console.WriteLine();
}

void UsingTupleDestructuring()
{
    Console.WriteLine(" Using Tuple Destructuring:");

    var (stringValue, boolValue, intValue) = MultipleValuesReturner.GetValuesUsingTuple();

    Console.WriteLine(stringValue);
    Console.WriteLine(boolValue);
    Console.WriteLine(intValue);

    Console.WriteLine();
}

void UsingTupleLiterals()
{
    Console.WriteLine(" Using Tuple Literals:");

    var (stringValue, boolValue, intValue) = MultipleValuesReturner.GetValuesUsingTupleLiterals();

    Console.WriteLine(stringValue);
    Console.WriteLine(boolValue);
    Console.WriteLine(intValue);

    Console.WriteLine();
}

void UsingOutKeyword()
{
    Console.WriteLine(" Using Out Keyword:");

    string stringValue;
    bool boolValue;
    int intValue;

    MultipleValuesReturner.GetValuesUsingOutKeyword(out stringValue, out boolValue, out intValue);

    Console.WriteLine(stringValue);
    Console.WriteLine(boolValue);
    Console.WriteLine(intValue);

    Console.WriteLine();
}

void UsingObjectInstance()
{
    Console.WriteLine(" Using Object Instance:");

    var multipleValues = MultipleValuesReturner.GetValuesUsingObjectInstance();

    Console.WriteLine(multipleValues.StringValue);
    Console.WriteLine(multipleValues.BoolValue);
    Console.WriteLine(multipleValues.IntValue);

    Console.WriteLine();
}

void UsingDictionary()
{
    Console.WriteLine(" Using Dictionary:");

    var multipleValues = MultipleValuesReturner.GetValuesUsingDictionary();

    Console.WriteLine(multipleValues["stringValue"]);
    Console.WriteLine(multipleValues["boolValue"]);
    Console.WriteLine(multipleValues["intValue"]);

    Console.WriteLine();
}

void UsingArrayOfObject()
{
    Console.WriteLine(" Using Array of Object:");

    var multipleValues = MultipleValuesReturner.GetValuesUsingArrayOfObject();

    Console.WriteLine(multipleValues[0]);
    Console.WriteLine(multipleValues[1]);
    Console.WriteLine(multipleValues[2]);

    Console.WriteLine();
}