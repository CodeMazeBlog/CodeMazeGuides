namespace ValueAndReferenceTypes
{
    public struct ValueTypeRectangle
    {
        public int breadth;
        public int length;
        public int area;
        public int Area()
        {
            int area = length * breadth;
            Console.WriteLine($"length = {length}");
            Console.WriteLine($"breadth = {breadth}");
            Console.WriteLine($"area = {area}");

            return area;
        }
    }
}
