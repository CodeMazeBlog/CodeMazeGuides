
namespace FuncDelegate
{
    public class Program
    {

        static void Main(string[] args)
        {
            Geometrics geometrics = new Geometrics();  

            Func<int,int, int> rectangle = geometrics.Rectangle;
            Func<float, float> circle = geometrics.Circle;                       

            int rectangle1 = rectangle(5, 8);
            float circle1 = circle(6);

            Console.WriteLine($"The area of a rectangle is: {rectangle1}");
            Console.WriteLine($"The area of the circle is: {circle1}");

        }


    }


}
