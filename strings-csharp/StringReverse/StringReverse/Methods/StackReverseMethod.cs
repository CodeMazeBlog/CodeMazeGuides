using System.Text;

namespace StringReverse
{
    public partial class Methods
    {
        public static string? StackReverseMethod(string stringToReverse)
        {
            var resultStack = new Stack<char>();
            foreach (char c in stringToReverse)
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