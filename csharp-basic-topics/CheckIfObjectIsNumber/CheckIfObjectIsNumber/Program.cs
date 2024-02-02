namespace CheckIfObjectIsNumber
{
    public class Program
    {
        static void Main()
        {
            var boolResult1 = Methods.CheckIfIntegerWithEqualityOperator(123);
            Console.WriteLine(boolResult1);

            var boolResult2 = Methods.CheckIfIntegerWithEqualityOperator(456D);
            Console.WriteLine(boolResult2);

            var boolResult3 = Methods.CheckIfIntegerWithEqualityOperator(0);
            Console.WriteLine(boolResult3);

            var floatResult = Methods.CheckIfFloatWithExplicitCasting(-2.5F);
            Console.WriteLine(floatResult);

            try
            {
                floatResult = Methods.CheckIfFloatWithExplicitCasting(5L);
            }
            catch (InvalidCastException)
            { 
                Console.WriteLine(typeof(InvalidCastException));
            }
            
            try
            {
                floatResult = Methods.CheckIfFloatWithExplicitCasting(5.0D);
            }
            catch (InvalidCastException)
            { 
                Console.WriteLine(typeof(InvalidCastException));
            }           

            var convertResult = Methods.CheckIfShortUsingConvert(5L);
            Console.WriteLine(convertResult);

            convertResult = Methods.CheckIfShortUsingConvert(19);
            Console.WriteLine(convertResult);

            convertResult = Methods.CheckIfShortUsingConvert(12.54F);
            Console.WriteLine(convertResult);
                                                    
            try
            {
                convertResult = Methods.CheckIfShortUsingConvert(Decimal.MaxValue);       
            }
            catch (OverflowException)
            { 
                Console.WriteLine(typeof(OverflowException)); 
            }

            convertResult = Methods.CheckIfShortUsingConvert("255");
            Console.WriteLine(convertResult);
                                                  
            try
            {
                convertResult = Methods.CheckIfShortUsingConvert("ABC");       
            }
            catch (FormatException)
            {
                Console.WriteLine(typeof(FormatException));
            }

            var isFloat = Methods.CheckIfFloatWithIsOperator(6.99F);
            Console.WriteLine(isFloat);

            isFloat = Methods.CheckIfFloatWithIsOperator(Math.PI);
            Console.WriteLine(isFloat);

            var intValue = Methods.ConvertToIntWithAsOperator(19);
            Console.WriteLine(intValue);

            intValue = Methods.ConvertToIntWithAsOperator(.25);
            Console.WriteLine(intValue);

            object value = "123";
            var isNumber = value.IsNumber();
            Console.WriteLine(isNumber);
            value = 123;
            isNumber = value.IsNumber();
            Console.WriteLine(isNumber);

            var price = Methods.CalculateAllTaxesIncludedPrice(10.0);
            Console.WriteLine(price);

            price = Methods.CalculateAllTaxesIncludedPrice(20);
            Console.WriteLine(price);
        }
    }
}