using System;

ActionExample();
// Define a Func delegate that takes a string "hardware" as an argument and returns a string.



public partial class Program
{
    // Define an Action delegate that takes a string "hardware" as an argument and returns void.
    public static void ActionExample()
    {
        Action<string> prepareHardware = (hardware) => Console.WriteLine($"Preparing Hardware: {hardware}");

        prepareHardware("Mouse");
    }
}