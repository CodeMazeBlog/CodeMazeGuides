namespace ValueAndReferenceTypes
{
    public class PassByValueAndReferenceSample
    {
        public int PassValueTypesByValue(int counter)
        {
            counter = counter + 1;
            Console.WriteLine($"Value inside function, counter = {counter}");

            return counter;
        }

        public int PassReferenceTypesByValue(ReferenceTypeRectangle rect)
        {
            Console.WriteLine($"Value inside function before assigment, Length = {rect.Length} and Breadth = {rect.Breadth}");              
            rect = new ReferenceTypeRectangle
            {
                Length = 10,
                Breadth = 10
            };
            Console.WriteLine($"Value inside function after assigment, Length = {rect.Length} and Breadth = {rect.Breadth}");

            return rect.Length * rect.Breadth;
        }
        public int PassValueTypesByReference(ref int counter)
        {
            counter = counter + 1;
            Console.WriteLine($"Value inside function, counter = {counter}");

            return counter;
        }

        public int PassReferenceTypesByReference(ReferenceTypeRectangle rect)
        {
            Console.WriteLine($"Value inside function before assigment, Length = {rect.Length} and Breadth = {rect.Breadth}");
            rect.Length = 10;
            rect.Breadth = 10;
            Console.WriteLine($"Value inside function after assigment, Length = {rect.Length} and Breadth = {rect.Breadth}");

            return rect.Length * rect.Breadth;
        }
    }
}
