namespace ActionFuncInCSharp
{
    public class BasicCalculator
    {

        #region Print Basic Calculation 
        public void AdditionPrint(int n1, int n2) => Console.WriteLine(n1 + n2);
        public void SubtractionPrint(int n1, int n2) => Console.WriteLine(n1 - n2);
        public void MultiplicationPrint(int n1, int n2) => Console.WriteLine(n1 * n2);
        public void DivisionPrint(int n1, int n2) => Console.WriteLine(n1 / n2);
        public void AdditionPrint(float n1, float n2) => Console.WriteLine(n1 + n2);
        public void SubtractionPrint(float n1, float n2) => Console.WriteLine(n1 - n2);
        public void MultiplicationPrint(float n1, float n2) => Console.WriteLine(n1 * n2);
        public void DivisionPrint(float n1, float n2) => Console.WriteLine(n1 / n2);
        #endregion

        #region int methods
        public int Addition(int n1, int n2) => n1 + n2;
        public int Subtraction(int n1, int n2) => n1 - n2;
        public int Multiplication(int n1, int n2) => n1 * n2;
        public int Division(int n1, int n2) => n1 / n2;
        #endregion

        #region float methods
        public float Addition(float n1, float n2) => n1 + n2;
        public float Subtraction(float n1, float n2) => n1 - n2;
        public float Multiplication(float n1, float n2) => n1 * n2;
        public float Division(float n1, float n2) => n1 / n2;
        #endregion
    }

}
