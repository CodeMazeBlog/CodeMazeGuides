namespace FuncActionDelegate
{
    public class ActionSample
    {
        public void Greeting(List<string> names)
        {
            Action<string> greet = name => Console.WriteLine($"Hello, {name}!");

            names.ForEach(greet);
        }
    }
}


