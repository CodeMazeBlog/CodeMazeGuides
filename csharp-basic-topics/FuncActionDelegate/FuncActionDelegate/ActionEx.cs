
namespace FuncActionDelegate
{
    public class ActionEx
    {
        public void ActionExample()
        {
            Action<string> PrintMessage = Console.WriteLine;
            PerformOperation(5, PrintMessage); // Invokes PrintMessage indirectly
            void PerformOperation(int value, Action<string> action)
            {
                string message = $"The value is: {value}";
                action(message); // Output: The value is: 5
            }
        }
        public void ActionRealExample()
        {
            List<string> data = new() { "Test1", "Test2", "Test3" };
            data.ForEach(x => Console.WriteLine(x));
        }
    }
   
}
