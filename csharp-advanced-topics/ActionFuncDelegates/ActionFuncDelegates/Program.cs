using static ActionFuncDelegates.ActionDelegateExample;
using static ActionFuncDelegates.FuncDelegateExample;

namespace ActionFuncDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            ActionProgram(numbers);

            var sentence = "Sentence example";

            FuncProgram(sentence);
        }
    }
}
