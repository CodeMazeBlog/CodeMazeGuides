using StaticVsNonstaticMethods;

Console.WriteLine("\n\n About user");
UsingUserObject();

Console.WriteLine("\n\n About 2D objects"); 
Display2DObjects();

Console.WriteLine("\n\n About dog");
PlayWithDog();

void UsingUserObject()
{
    var user = new User()
    {
        Email = "test_user@gmail.com",
        Password = "ThisIs3asyPa$$word"
    };

    Console.WriteLine($"Email is correct: { user.CheckEmail() }");
    Console.WriteLine($"Password is correct: { User.CheckPassword(user.Password) }");
    Console.WriteLine($"Whole object is correct: { user.CheckUser() }");
}

void Display2DObjects()
{
    var smallSquare = Square.Create(3);
    var smallSquare1 = new Square() { SideLength = 3 };

    Console.WriteLine(smallSquare.Surface());
    Console.WriteLine(Square.Description());
}

void PlayWithDog()
{
    Dog.Bark();
    Dog.Bark(5);
}