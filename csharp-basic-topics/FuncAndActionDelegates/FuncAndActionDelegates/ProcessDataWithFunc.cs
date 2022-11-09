namespace FuncAndActionDelegates
{
    public class ProcessDataWithFunc
    {
        public void Process()
        {
            //Simplest declaration with a return type and no parameters
            Func<int> simpleFunc;

            //1 parameter
            Func<int, int> funcWith1Param;

            //2 parameters
            Func<int, int, int> funcWith2Params;

            Func<int, int, int> doSomethingWithBothParamsAndReturnVal = CalculateSumWithReturnVal;

            var total = doSomethingWithBothParamsAndReturnVal(1, 2);
        }

        public int GetDataWithFunc(Func<int, int, int> addUpNumbers, int val1, int val2)
        {
            //Get some data, then call action
            return addUpNumbers(val1, val2);
        }

        public int CalculateSumWithReturnVal(int val1, int val2)
        {
            return val1 + val2;
        }
    }
}

