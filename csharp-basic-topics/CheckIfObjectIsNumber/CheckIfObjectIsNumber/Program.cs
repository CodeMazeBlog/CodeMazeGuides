using CheckIfObjectIsNumber;

Console.WriteLine($">>> Using {nameof(Methods.CheckIfIntegerWithEqualityOperator)}");
var boolResult = Methods.CheckIfIntegerWithEqualityOperator(123);
Console.WriteLine(boolResult);

boolResult = Methods.CheckIfIntegerWithEqualityOperator(456D);
Console.WriteLine(boolResult);

boolResult = Methods.CheckIfIntegerWithEqualityOperator(0);
Console.WriteLine(boolResult);

Console.WriteLine($">>> Using {nameof(Methods.CheckIfFloatWithExplicitCast)}");
boolResult = Methods.CheckIfFloatWithExplicitCast(-2.5F);
Console.WriteLine(boolResult);

boolResult = Methods.CheckIfFloatWithExplicitCast(5L);
Console.WriteLine(boolResult);
            
boolResult = Methods.CheckIfFloatWithExplicitCast(5.0D);
Console.WriteLine(boolResult);

Console.WriteLine($">>> Using {nameof(Methods.CheckIfShortUsingConvert)}");
var convertResult = Methods.CheckIfShortUsingConvert(5L);
Console.WriteLine(convertResult);

convertResult = Methods.CheckIfShortUsingConvert(19);
Console.WriteLine(convertResult);

convertResult = Methods.CheckIfShortUsingConvert(12.54F);
Console.WriteLine(convertResult);
                                                    
convertResult = Methods.CheckIfShortUsingConvert("255");
Console.WriteLine(convertResult);
                                                  
convertResult = Methods.CheckIfShortUsingConvert(Decimal.MaxValue);
Console.WriteLine(convertResult);

convertResult = Methods.CheckIfShortUsingConvert("ABC");
Console.WriteLine(convertResult);

Console.WriteLine($">>> Using {nameof(Methods.CheckIfFloatWithIsOperator)}");
var isFloat = Methods.CheckIfFloatWithIsOperator(6.99F);
Console.WriteLine(isFloat);

isFloat = Methods.CheckIfFloatWithIsOperator(Math.PI);
Console.WriteLine(isFloat);

Console.WriteLine($">>> Using {nameof(Methods.CheckIfIntWithAsOperator)}");
var intValue = Methods.CheckIfIntWithAsOperator(19);
Console.WriteLine(intValue);

intValue = Methods.CheckIfIntWithAsOperator(.25);
Console.WriteLine(intValue);

Console.WriteLine(">>> Using object.IsNumber");
object value = "123";
var isNumber = value.IsNumber();
Console.WriteLine(isNumber);
value = 123;
isNumber = value.IsNumber();
Console.WriteLine(isNumber);

Console.WriteLine($">>> Using {nameof(Methods.CalculateAllTaxesIncludedPrice)}");
var price = Methods.CalculateAllTaxesIncludedPrice(10.0);
Console.WriteLine(price);

price = Methods.CalculateAllTaxesIncludedPrice(20);
Console.WriteLine(price);