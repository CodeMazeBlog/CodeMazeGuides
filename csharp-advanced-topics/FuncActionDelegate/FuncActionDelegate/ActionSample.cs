namespace FuncActionDelegate
{
    public class ActionSample
    {
        public void Greeting(List<string> names)
        {
            Action<string> greet = name => Console.WriteLine($"Hello, {name}!");

            // Iterate over each name in the list and apply the Action delegate
            names.ForEach(greet);
        }
    }
}


