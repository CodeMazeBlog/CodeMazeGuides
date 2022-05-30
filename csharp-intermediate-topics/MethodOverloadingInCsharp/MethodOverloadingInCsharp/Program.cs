using System;

namespace MethodOverloadingInCsharp
{
    public class Program
    {
        public int AddNumbers(int num1, int num2) 
        { 
            return num1 + num2; 
        } 
        public int AddNumbers(int num1, int num2, int num3) 
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
        public static void Main(string[] args)
        {
            var program = new Program(); 
            var sum1 = program.AddNumbers(1, 2); 
            var sum2 = program.AddNumbers(1, 2, 3);

            var obj1 = program.Append(1); 
            var obj2 = program.Append("one");

            var val1 = program.Order(1, "item"); 
            var val2 = program.Order("item", 2);
        }
    }
}
