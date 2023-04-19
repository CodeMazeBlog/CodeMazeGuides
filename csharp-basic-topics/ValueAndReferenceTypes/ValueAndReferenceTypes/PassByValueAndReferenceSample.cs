namespace ValueAndReferenceTypes
{
    public class PassByValueAndReferenceSample
    {
        public int PassByValue(int counter)
        {
            counter = counter + 1;
            Console.WriteLine($"Inside PassByValue counter = {counter}");

            return counter;
        }

        public int PassByReference(ref int counter)
        {
            counter = counter + 1;
            Console.WriteLine($"Inside PassByReference counter = {counter}");

            return counter;
        }
    }
}
