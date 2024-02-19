namespace ActionAndFuncDelegates
{
    public static class LinqController
    {
        public static Action<string> hello = (name) => Console.WriteLine("Hello " + name);

        public static void SayHello()
        {
            var list = new List<string>() { "Marc", "Jennifer", "Alex" };

            list.ForEach(x => hello(x));
        }
    }
}
