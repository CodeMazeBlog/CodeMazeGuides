namespace PassingOutputParametersToStoredProcedures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var result = BusinessLogic.InsertNewDeveloper("Johdn", "C#");
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}