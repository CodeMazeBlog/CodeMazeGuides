public class AccessingUnderlyingValuesOfNullableTypes
{
    byte? weekDay = 24;
    int? number = null;  

    public static int? AccessingUnassignedValues(int? num)
    {
        int? number;

        //Console.WriteLine(number.ToString()); 

        return number = num;
    }

    void UsingNullableProperties()
    {
        int result = number.GetValueOrDefault();
        bool hasValue = number.HasValue;
        //int value = number.Value;

        /*if (number.HasValue)
        {
            Console.WriteLine(number.Value);
        }

        if (number != null)
        {
            Console.WriteLine(number.Value);
        }*/
    }
}



