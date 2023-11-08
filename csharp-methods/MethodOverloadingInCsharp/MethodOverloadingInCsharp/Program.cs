namespace MethodOverloadingInCsharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var overload = new Overload();
            var sum1 = overload.AddNumbers(1, 2);
            var sum2 = overload.AddNumbers(1, 2, 3);

            var obj1 = overload.Append(1);
            var obj2 = overload.Append("one");

            var val1 = overload.Order(1, "item");
            var val2 = overload.Order("item", 2);

            var derived = new Derived();
            var sum3 = derived.AddNumbers(1, 2);
            var sum4 = derived.AddNumbers(1, 2, 3); 
        }
    }

}
