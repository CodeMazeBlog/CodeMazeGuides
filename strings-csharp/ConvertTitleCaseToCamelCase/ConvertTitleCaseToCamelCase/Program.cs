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

inputs.ToList().ForEach(x => Console.WriteLine($"'{x}' => {x.ToCamelCase()}"));