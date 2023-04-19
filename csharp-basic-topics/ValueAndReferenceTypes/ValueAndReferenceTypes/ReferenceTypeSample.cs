namespace ValueAndReferenceTypes
{
    public class ReferenceTypeRectangle
    {
        private int _length = 50;
        private int _breadth = 20;
        public int length { 
            get { return _length; } 
            set { _length = value; }
        }
        public int breadth
        {
            get { return _breadth; }
            set { _breadth = value; }
        }     
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
