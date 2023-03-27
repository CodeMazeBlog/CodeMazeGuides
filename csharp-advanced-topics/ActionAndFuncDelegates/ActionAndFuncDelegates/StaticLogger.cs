namespace ActionAndFuncDelegates
{
    public static class StaticLogger
    {
        public static void LogToConsole(IShape shape)
        {
            Console.WriteLine($"New shape of type {shape.ShapeType} has been created.");
        }

        public static void LogToFile(IShape shape)
        {
            File.AppendAllLines("shape_log.txt", new List<string> { $"New shape of type {shape.ShapeType} has been created." });
        }
    }
}
