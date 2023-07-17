namespace SourceGeneratorInCSharp
{
    using Services;

    public class Program
    {
        public static void Main(string[] args)
        {
            HelloWorld.SayHello();
            SyntaxFactoryHelloWorld.SayHello();

            var personModelService = new PersonModelService();

            personModelService.Add(new() { Id = 1, Name = "Mathew" });
            personModelService.All().ForEach(x => Console.WriteLine(x.Name));
        }
    }
}