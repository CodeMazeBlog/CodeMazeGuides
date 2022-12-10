namespace NullableTypesInCSharp
{
    public class UsingComparisonOperators
    {
        public static bool Run()
        {
            int? countOne = null;
            int? countTwo = null;

            bool areEqual = countOne > countTwo; //false
            bool areEqualTwo = countOne < countTwo; //false

            int? countThree = 12;
            int? countFour = 14;

            return countFour > countThree; //true            
        }
    }

    public class UsingNullCoalescingOperator
    {
        public static int? Run()
        {
            int? count = null;
            long? id = count ?? 1;

            return count ??= 13;
        }
    }
}
