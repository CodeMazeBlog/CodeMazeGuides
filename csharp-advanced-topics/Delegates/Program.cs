using System;
class Program
{
    static public void Main()
    {
        //Func Delegate
        //  Func<int, int, decimal> Get_Percentage = Func_Delegates.Func_Delegate_Class.Percentage_Calculation;
        Func<int, int, decimal> Get_Percentage = Percentage_Calculation;
        decimal MarksPercent = Get_Percentage(320, 500);
        Console.WriteLine($"{MarksPercent }");

        //Action Delegate
        // Action<string, string> Concate = Action_Delegates.Action_Delegate_Class.GetCompleteName;
        Action<string, string> Concate = GetCompleteName;
        Concate("Ricky", "Martin ");
    }


    public static void GetCompleteName(string FName, string LName)
    {
        string CompleteName = FName + " " + LName;

        Console.WriteLine($"{CompleteName }");
    }

    public static decimal Percentage_Calculation(int marks, int total)
    {
        return (((decimal)marks / total) * 100);
    }
}
