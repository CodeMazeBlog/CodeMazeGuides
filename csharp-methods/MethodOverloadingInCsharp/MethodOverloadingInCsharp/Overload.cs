namespace MethodOverloadingInCsharp
{
    public class Overload
    {
        public int AddNumbers(int num1, int num2)
        {
            return num1 + num2;
        }

        public double AddNumbers(int num1, int num2, int num3)
        {
            return num1 + num2 + num3;
        }

        public string Append(int numb)
        {
            return $"Value is: {numb}";
        }

        public string Append(string numb)
        {
            return $"Value is: {numb}";
        }

        public string Order(int numb, string item)
        {
            return item + numb;
        }

        public string Order(string item, int numb)
        {
            return item + numb;
        }
    }
}
