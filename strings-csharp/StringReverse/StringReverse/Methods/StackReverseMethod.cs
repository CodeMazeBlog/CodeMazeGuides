using System.Text;

namespace StringReverse
{
    public partial class Methods
    {
        public static string? StackReverseMethod(string s)
        {
            var resultStack = new Stack<char>();
            foreach (char c in s)
            {
                resultStack.Push(c);
            }

            var sb = new StringBuilder();
            while (resultStack.Count > 0)
            {
                sb.Append(resultStack.Pop());
            }

            return sb.ToString();
        }
    }
}