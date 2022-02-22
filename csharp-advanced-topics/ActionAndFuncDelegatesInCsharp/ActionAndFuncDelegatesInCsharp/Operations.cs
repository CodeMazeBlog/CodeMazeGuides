namespace ActionAndFuncDelegatesInCsharp
{
    public class Operations
    {
        public readonly string Name = "Joe";

        public void SayHi()
        {
            Console.WriteLine($"Hi, {Name}");
        }

        public static void SayHiToFullName(string firtsName, string lastName)
        {
            Console.WriteLine($"Hi, {firtsName} {lastName}");
        }

        public string GetName()
        {
            return Name;
        }

        public static int Sum(int x, int y)
        {
            return x + y;
        }


    }
}
