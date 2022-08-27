namespace Func_Action_Delegate_Library.Action
{
    public class ActionWithAnnonymousMethod
    {
        public static string Result { get; set; }
        public Action<string, string> concatString = delegate (string a, string b)
        {
            Result = a + b;
        };
    }
}
