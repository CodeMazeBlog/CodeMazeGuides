namespace StaticVsNonstaticMethods
{
    public class Dog
    {
        public string Name { get; set; }

        public static void Bark()
        {
            Console.WriteLine("Woof");
        }

        public static void Bark(int barkCount)
        {
            for (int i = 0; i < Math.Min(20, barkCount); i++) 
            {
                Console.WriteLine("Woof");
            }
        }
    }
}
