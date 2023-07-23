using ConvertTitleCaseToCamelCase;

var inputs = new[]
{
    "Welcome to the Maze",
    "Welcome To The Maze",
    "WelcomeToTheMaze",
    "Welcome_To_The_Maze",
    "ISODate",
    "IOStream"
};

foreach (var x in inputs)
{
    Console.WriteLine($"{x} => {x.ToCamelCase()}");
}