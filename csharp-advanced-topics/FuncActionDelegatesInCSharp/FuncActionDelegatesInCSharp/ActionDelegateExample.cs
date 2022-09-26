namespace FuncActionDelegatesInCSharp
{
    public class ActionDelegateExample
    {
        public string? CodeMazeMessage { get; set; }

        public void RunActionDelegateExample()
        {
            //Action delegate example
            Action<string> actionmessage = DisplayCodeMazeMessage;
            actionmessage.Invoke("CodeMaze is best source of C# action delegate info online.");
        }
        public void DisplayCodeMazeMessage(string message)
        {
           CodeMazeMessage = message;
            Console.WriteLine(CodeMazeMessage);
        }
    }
}
