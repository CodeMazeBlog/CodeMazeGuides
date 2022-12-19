using System.ComponentModel;

namespace Net7.Delgates;


/// Declaration
/// <summary>
/// public is the access-modifier
/// delegate is the keyword
/// void is the retun type
/// Display is user defined delegate name
/// value is the only parameter 
/// </summary>
/// <param name="value"></param>
public delegate void Display(string value);

/// Declaration
/// <summary>
/// public is the access-modifier
/// delegate is the keyword
/// void is the return type
/// PrintMessage is user defined delegate name
/// value is the only parameter 
/// </summary>
/// <param name="value"></param>
public delegate void PrintMessage(string message);


/// <summary>
/// public is the access-modifier
/// delegate is the keyword
/// string is the return type
/// Display is user defined delegate name
/// firstName is the first parameter 
/// lastName is the second parameter 
/// </summary>
/// <param name="firstName"></param>
/// <param name="lastName"></param>
/// <returns> full name which contain firstName and lastName</returns>
public delegate string FullName(string firstName, string lastName);


public class Program
{
    public static void DisplayMessage(string message) => Console.WriteLine(message);

    public static void PrintMessage(string value) => Console.WriteLine(value);

    public static string FullName(string firstName, string lastName) => $"{firstName} {lastName}";

    static void Main(string[] args)
    {

        //Create instance
        var displayMessage = new Display(DisplayMessage);
        // calling
        displayMessage.Invoke("Hello, World!");

        // assigning
        Func<string, string, string> getFullName = FullName;
        // calling
        var result = getFullName.Invoke("Kanhaya", "Tyagi");
        Console.WriteLine(result);


        // assigning
        Action<string> print = PrintMessage;
        // calling
        print.Invoke("Greeting from Kanhaya Tyagi");
    }
}