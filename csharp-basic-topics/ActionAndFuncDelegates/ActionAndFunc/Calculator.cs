using System.Linq;

namespace ActionAndFunc;
public class Calculator
{
    public delegate TResult Operation<TOp1, TOp2, TResult>(TOp1 op1, TOp2 op2);

    public TOperand ExecuteOperationOverListWithDelegate<TOperand>(
            Operation<TOperand, TOperand, TOperand> operation, 
            params TOperand[] operands)
    {
        var result = operands[0];
        foreach (var operand in operands.Skip(1))
        {
            result = operation(result, operand);
        }

        return result;
    }

    public TOperand ExecuteOperationOverListWithFunc<TOperand>(
            Func<TOperand, TOperand, TOperand> operation, 
            params TOperand[] operands)
    {
        return operands.Aggregate(operation);
    }
}
