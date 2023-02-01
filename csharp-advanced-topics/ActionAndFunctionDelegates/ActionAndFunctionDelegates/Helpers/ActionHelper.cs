namespace ActionAndFunctionDelegates.Helpers
{
    public class ActionHelper
    {
        public void printValue(string value, int count)
        {
            for(int i =0; i < count; i++)
            {
                Console.WriteLine(value);
            }
        }
    }
}
