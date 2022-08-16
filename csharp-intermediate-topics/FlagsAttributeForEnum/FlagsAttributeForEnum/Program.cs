using FlagsAttributeForEnum;

var audience = UserType.None;

audience = audience.Add(UserType.Employee, UserType.Customer);
audience.Print();

audience = audience.Remove(UserType.Driver);
audience.Print();

if (audience.CustomHasFlag(UserType.Driver)) // or use HasFlag
{
    Console.WriteLine("Driver exist.");
}
else
{
    Console.WriteLine("Driver doesn't exist.");
    Console.WriteLine("Adding Driver...");
    audience = audience.Add(UserType.Driver);
}
audience.Print();