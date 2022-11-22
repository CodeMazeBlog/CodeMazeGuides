namespace ActionFuncInCSharp
{
    public class FloatBasicCalculator
    {
        public void AdditionPrint(float n1, float n2) => Console.WriteLine(n1 + n2);

        public void SubtractionPrint(float n1, float n2) => Console.WriteLine(n1 - n2);
        
        public void MultiplicationPrint(float n1, float n2) => Console.WriteLine(n1 * n2);
        
        public void DivisionPrint(float n1, float n2) => Console.WriteLine(n1 / n2);

        public float Addition(float n1, float n2) => n1 + n2;
        
        public float Division(float n1, float n2) => n1 / n2;
        
        public float Multiplication(float n1, float n2) => n1 * n2;
        
        public float Subtraction(float n1, float n2) => n1 - n2;
    }
}