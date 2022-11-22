namespace ActionFuncInCSharp
{
    public class IntBasicCalculator
    {
        public void AdditionPrint(int n1, int n2) => Console.WriteLine(n1 + n2);
        
        public void SubtractionPrint(int n1, int n2) => Console.WriteLine(n1 - n2);
        
        public void MultiplicationPrint(int n1, int n2) => Console.WriteLine(n1 * n2);
        
        public void DivisionPrint(int n1, int n2) => Console.WriteLine(n1 / n2);

        public int Addition(int n1, int n2) => n1 + n2;
        
        public int Subtraction(int n1, int n2) => n1 - n2;
        
        public int Multiplication(int n1, int n2) => n1 * n2;
        
        public int Division(int n1, int n2) => n1 / n2;
    }
}