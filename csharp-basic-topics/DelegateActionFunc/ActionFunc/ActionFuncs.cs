namespace ActionFunc
{
    public class ActionFuncs
    {
        // See https://aka.ms/new-console-template for more information
        static int result = 0;

        public static int SumFunc()
        {
            int Sum(int a, int b) => a + b;

            result = Sum(3, 4);

            return result;
        }

        public static int AdditionAction()
        {

            Action<int, int> ActionCalculatorAddition = (a, b) =>
            {
                result = a + b;
            };

            ActionCalculatorAddition(10, 20);

            return result;
        }

        public static int SubtractionAction()
        {

            Action<int, int> ActionCalculatorSubtraction = (a, b) =>
            {
                result = b - a;
            };

            ActionCalculatorSubtraction(10, 20);
            return result;
        }

        public static int MultiplicationAction()
        {

            Action<int, int> ActionCalculatorMultiplication = (a, b) =>
            {
                result = a * b;
            };
            ActionCalculatorMultiplication(10, 20);
            return result;
        }

        public static int DivisionAction()
        {

            Action<int, int> ActionCalculatorDivision = (a, b) =>
            {
                result = b / a;
            };

            ActionCalculatorDivision(10, 20);

            return result;
        }
    }
}
