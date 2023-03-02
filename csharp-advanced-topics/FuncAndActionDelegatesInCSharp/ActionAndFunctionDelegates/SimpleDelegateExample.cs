using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_and_Function_Delegates
{
    delegate int Calculator(int numberToBeProcessed);

    public class SimpleDelegateExample
    {
        static int Number = 5220; 

        public static int Add(int numberToBeAdded)
        {
            return Number += numberToBeAdded; 
        }

        public static int Substract(int numberToBeSubstracted)
        {
            return Number -= numberToBeSubstracted;
        }

        public static int Multiply(int numberToBeMultiplied) 
        {
            return Number *= numberToBeMultiplied;
        }

        public static int Divide(int numberToBeDivided) 
        {
            return Number / numberToBeDivided;
        }

        public static int Modulus(int  numberToBeModulus) 
        {
            return Number % numberToBeModulus;
        }

        public static int GetNumber()
        {
            return Number;
        }
    }
}
