namespace ValueAndReferenceTypes
{
    public struct ValueTypeRectangle
    {
        public int Length { get; set; }
        public int Breadth { get; set; }

        public int Area()
        {
            int area = Length * Breadth;
            Console.WriteLine($"length = {Length}");
            Console.WriteLine($"breadth = {Breadth}");
            Console.WriteLine($"area = {area}");

            return area;
        }
    }
}
