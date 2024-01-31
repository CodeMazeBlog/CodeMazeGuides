namespace CheckIfObjectIsNumber
{
    public class Program
    {
        static void Main()
        {
            var boolResult1 = Methods.CheckIfIntegerWithEqualityOperator(123);    // Returns True 
            Console.WriteLine(boolResult1);

            var boolResult2 = Methods.CheckIfIntegerWithEqualityOperator(456D);       // Returns False
            Console.WriteLine(boolResult2);

            var boolResult3 = Methods.CheckIfIntegerWithEqualityOperator(0);          // Returns True
            Console.WriteLine(boolResult3);

            var floatResult = Methods.CheckIfFloatWithExplicitCasting(-2.5F);
            Console.WriteLine(floatResult);   // Returns -2.5

            try
            {
                floatResult = Methods.CheckIfFloatWithExplicitCasting(5L);  // System.InvalidCastException
            }
            catch (InvalidCastException)
            { 
                Console.WriteLine(typeof(InvalidCastException));
            }
            
            try
            {
                floatResult = Methods.CheckIfFloatWithExplicitCasting(5.0D);         // System.InvalidCastException
            }
            catch (InvalidCastException)
            { 
                Console.WriteLine(typeof(InvalidCastException));
            }           

            var convertResult = Methods.CheckIfShortUsingConvert(5L);
            Console.WriteLine(convertResult);       // Returns 5 

            convertResult = Methods.CheckIfShortUsingConvert(19);
            Console.WriteLine(convertResult);       // Returns 19

            convertResult = Methods.CheckIfShortUsingConvert(12.54F);
            Console.WriteLine(convertResult);       // Returns 13
                                                    
            try
            {
                convertResult = Methods.CheckIfShortUsingConvert(Decimal.MaxValue); // System.OverflowException       
            }
            catch (OverflowException)
            { 
                Console.WriteLine(typeof(OverflowException)); 
            }

            convertResult = Methods.CheckIfShortUsingConvert("255");
            Console.WriteLine(convertResult);       // Returns 255
                                                  
            try
            {
                convertResult = Methods.CheckIfShortUsingConvert("ABC"); // System.FormatException       
            }
            catch (FormatException)
            {
                Console.WriteLine(typeof(FormatException));
            }

            var isFloat = Methods.CheckIfFloatWithIsOperator(6.99F);
            Console.WriteLine(isFloat);     // Returns True

            isFloat = Methods.CheckIfFloatWithIsOperator(Math.PI);
            Console.WriteLine(isFloat);     // Returns False

            var intValue = Methods.ConvertToIntWithAsOperator(19);
            Console.WriteLine(intValue);     // Returns 19

            intValue = Methods.ConvertToIntWithAsOperator(.25);
            Console.WriteLine(intValue);     // Returns 0

            object value = "123";
            var isNumber = value.IsNumber();
            Console.WriteLine(isNumber);    // Returns False
            value = 123;
            isNumber = value.IsNumber();
            Console.WriteLine(isNumber);    // Returns True

            var price = Methods.CalculateAllTaxesIncludedPrice(10.0);
            Console.WriteLine(price);       // Returns 30.8

            price = Methods.CalculateAllTaxesIncludedPrice(20);
            Console.WriteLine(price);       // Returns 28
        }
    }
}