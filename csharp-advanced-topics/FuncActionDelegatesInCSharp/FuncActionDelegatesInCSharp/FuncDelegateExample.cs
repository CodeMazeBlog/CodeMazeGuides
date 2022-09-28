namespace FuncActionDelegatesInCSharp
{
    public class FuncDelegateExample
    {
        public string? CodeMazeMessage { get; set; }

        public void RunFuncDelegateExample()
        {
            //Func delegate example
            Func<string> funcmessage = GetCodeMazeMessage;
            CodeMazeMessage = funcmessage.Invoke();
        }

        public string GetCodeMazeMessage()
        {
            return ("CodeMaze is best source of C# func delegate info online.");
        }

    }
}
