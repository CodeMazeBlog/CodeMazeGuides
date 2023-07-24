var input = new InputOutput();

input.Read(ReadFromConsole);

input.Write(WriteToConsole);

Console.ReadLine();

string ReadFromConsole()
{
    Console.WriteLine("Please enter some text to count the characters :");
    return Console.ReadLine();
}

void WriteToConsole(string input)
{
    Console.WriteLine(Environment.NewLine);
    Console.WriteLine(input);
}