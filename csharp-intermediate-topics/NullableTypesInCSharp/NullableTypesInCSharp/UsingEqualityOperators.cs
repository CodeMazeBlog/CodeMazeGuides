namespace NullableTypesInCSharp
{
    internal class UsingEqualityOperators
    {
        public void Run()
        {
            bool? isRunning = null;
            bool? isDisposed = null;
            bool? isActive = true;
            bool? isHuman = false;

            bool areEqual = isDisposed == isRunning; //true
            bool areEqualTwo = isDisposed == isActive; //false
            bool areEqualThree = isActive == isHuman; //
        }
    }

    internal class UsingInEqualityOperators
    {
        public void Run()
        {
            bool? isRunning = null;
            bool? isDisposed = null;
            bool? isActive = true;
            bool? isHuman = false;

            bool areEqual = isDisposed != isRunning; //false
            bool areEqualTwo = isDisposed != isActive; //true
            bool areEqualThree = isActive != isHuman; // true
        }
    }
}
