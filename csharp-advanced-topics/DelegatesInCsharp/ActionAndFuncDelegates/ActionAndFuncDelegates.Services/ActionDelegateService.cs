namespace ActionAndFuncDelegates.Services
{
    public class ActionDelegateService
    {
        // Action delegate for greeting
        public Action<string>? GreetAction;

        // Action delegate for event registration
        public Action<List<string>, string>? EventRegistrationAction;



        // Method to trigger the GreetAction delegate
        public void Greet(string name)
        {
            GreetAction?.Invoke(name);
        }

        public void RegisterForEvent(List<string> eventNames, string userName)
        {
            
            // Trigger the EventRegistrationAction delegate to execute additional tasks
            EventRegistrationAction?.Invoke(eventNames, userName);
        }




    }
}