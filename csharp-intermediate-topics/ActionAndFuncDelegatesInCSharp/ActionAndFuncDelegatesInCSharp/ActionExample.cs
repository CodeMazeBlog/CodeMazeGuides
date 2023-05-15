namespace ActionAndFuncDelegatesInCSharp
{
    public class ActionExample
    {
        public string TextToDisplay { get; set; } = string.Empty;
        public ActionExample()
        {
            Action<string> greetNewReader = DisplayWelcomeMessageToNewReader;
            greetNewReader("Samuel"); //This outputs: Hello Samuel! Welcome to CodeMaze, the best C# blog
        }

        public void DisplayWelcomeMessageToNewReader(string name)
        {
            TextToDisplay = $"Hello {name}! Welcome to CodeMaze, the best C# blog";
        }
    }
}