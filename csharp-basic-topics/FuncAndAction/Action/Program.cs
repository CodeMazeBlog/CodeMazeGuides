using System;

public class ActionDemo
{
    // Define an Action delegate that represents a method with one string as parameter and returns void
    static Action<string> ShowMessage;

    // A mehtod that we can use as with our action
    public static void ShowMessageWithBeep(string message)
    {
        Console.Beep();
        Console.WriteLine(message);

    }

    // A method 
    public static void ActionAsParameter(Action<string> myAction)
    {
        myAction("I'm an parameter");

    }


    static void Main()
    {

        //Set the Action to our method                    
        ShowMessage = ShowMessageWithBeep;

        ShowMessage("Hello World with Beep!!!");

        //Set the Action to the a differnt method
        ShowMessage = Console.WriteLine;

        ShowMessage("Hello World without Beep!!!");


        //We can also use a method as a parameter
        ActionAsParameter(ShowMessageWithBeep);

        ActionAsParameter(Console.WriteLine);

    }
}