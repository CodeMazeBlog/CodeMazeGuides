using System;

public class MyFuncDelegate
{
    public enum OperationType { Add, Subtract , Multiply , Divide };

    private  int Add(int x, int y) { return x + y; }
    private  int Subtract(int x, int y) { return x - y; }
    private  int Multiply(int x, int y) { return x * y; }
    private  int Divide(int x, int y) { return x / y; }

    public int PerformFunction(int x, int y, OperationType type = OperationType.Add)
    {
        Func<int, int, int> operation;
        switch (type)
        {
            case OperationType.Subtract:
                operation = Subtract;
                break;
            case OperationType.Multiply:
                operation = Multiply;
                break;
            case OperationType.Divide:
                operation = Divide;
                break;
            default:
                operation = Add;
                break;
        }
        return operation(x,y);
    }

    public void ByR(ref int x)
    {
        x += 200;
    }
}