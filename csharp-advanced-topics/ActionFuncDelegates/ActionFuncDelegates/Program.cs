using static ActionFuncDelegates.ActionDelegateExample;
using static ActionFuncDelegates.FuncDelegateExample;

namespace ActionFuncDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Action Delegate
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            ActionProgram(numbers);

            //Func Delegate
            string sentence = "Sentence example";

            FuncProgram(sentence);
        }
    }
}
