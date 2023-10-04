using ActionAndFuncDelegatesInCSharp;
using System;

ActionExample("Mouse");
ActionExampleWithOptions(opt =>
{
    opt.Keyboard = 2;
    opt.Webcam = 1;
    opt.Mouse = 2;
    opt.Microphone = 1;
});

var response = FuncExample();
Console.WriteLine(response);

var responseWithParams = FuncExampleWithParams("Keyboard", "Microphone");
Console.WriteLine(responseWithParams);

public partial class Program
{
    // Define an Action delegate that takes a string "hardware" as an argument and returns void.
    public static void ActionExample(string hardware)
    {
        Action<string> prepareHardware = (hware) => Console.WriteLine($"Action. Preparing Hardware: {hware}");

        prepareHardware(hardware);
    }

    // Define an Action delegate with options parameters in the method signature.
    public static void ActionExampleWithOptions(Action<Hardware> options)
    {
        if (options == null)
        {
            Console.WriteLine("No options provided.");
        }
        else
        {
            var hardware = new Hardware();
            options(hardware);
            Console.WriteLine($"Action. Preparing Keyboard(s): {hardware.Keyboard}");
            Console.WriteLine($"Action. Preparing Webcam(s): {hardware.Webcam}");
            Console.WriteLine($"Action. Preparing Mouse(s): {hardware.Mouse}");
            Console.WriteLine($"Action. Preparing Microphone(s): {hardware.Microphone}");
        }
    }

    public static string FuncExample()
    {
        Func<string> func = () => "Func. Preparing Hardware: Webcam";
        return func();
    }
    
    // Define a Func delegate that takes a string "hardware" as an argument and returns a string.
    public static string FuncExampleWithParams(string hardware1, string hardware2)
    {
        Func<string, string, string> prepareHardware = (hware1, hware2) 
            => $"Func. Preparing Hardware: {hware1} and {hware2}";

        return prepareHardware(hardware1, hardware2);
    }
}