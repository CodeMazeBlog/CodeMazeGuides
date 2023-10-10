namespace FuncActionDelegatesInCSharp.UseCases.Calculator;

public class IoHandler : IIoHandler
{
    public int GetUserInput()
    {
        var inputNumber = Console.ReadLine();
        return Convert.ToInt32(inputNumber);
    }
}