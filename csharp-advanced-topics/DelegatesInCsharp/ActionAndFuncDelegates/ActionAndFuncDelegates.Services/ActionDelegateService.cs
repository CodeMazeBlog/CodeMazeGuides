namespace ActionAndFuncDelegates.Services
{
    public class ActionDelegateService
    {
        // Action delegate for greeting
        public Action<string>? GreetAction;

        // Method to trigger the GreetAction delegate
        public void Greet(string name)
        {
            GreetAction?.Invoke(name);
        }
    }
}