namespace NullableTypesInCSharp
{
    public class UsingEqualityOperators
    {
        public static (bool areEqual, bool areEqualTwo, bool areEqualThree) Run()
        {
            bool? isRunning = null;
            bool? isDisposed = null;
            bool? isActive = true;
            bool? isHuman = false;

            bool areEqual = isDisposed == isRunning; //true
            bool areEqualTwo = isDisposed == isActive; //false
            bool areEqualThree = isActive == isHuman; //false

            return (areEqual, areEqualTwo, areEqualThree);
        }
    }

    public class UsingInEqualityOperators
    {
        public static (bool areEqual, bool areEqualTwo, bool areEqualThree) Run()
        {
            bool? isRunning = null;
            bool? isDisposed = null;
            bool? isActive = true;
            bool? isHuman = false;

            bool areEqual = isDisposed != isRunning; //false
            bool areEqualTwo = isDisposed != isActive; //true
            bool areEqualThree = isActive != isHuman; // true

            return (areEqual, areEqualTwo, areEqualThree);
        }
    }
}
