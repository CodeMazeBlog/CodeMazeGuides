using dotnet_console;

Console.WriteLine("1 - Basic Output");
Console.WriteLine("2 - Basic Input");
Console.WriteLine("3 - Show Colors");
Console.WriteLine("4 - Show Colors - Rotate");
Console.WriteLine("5 - Change Window and Buffer");
Console.WriteLine("6 - Read Single Character");

var result = Console.ReadKey();

switch (result.Key)
{
    case ConsoleKey.D1:
        BasicInputOutput.HelloWorld();
        break;

    case ConsoleKey.D2:
        BasicInputOutput.AskName();
        break;

    case ConsoleKey.D3:
        Colors.ShowColors();
        break;

    case ConsoleKey.D4:
        await Colors.ShowColorsRotate();
        break;

    case ConsoleKey.D5:
        ConsoleBuffer.ChangeHeightAndBuffer();
        break;

    case ConsoleKey.D6:
        BasicInputOutput.ReadSingleCharacter();
        break;
}