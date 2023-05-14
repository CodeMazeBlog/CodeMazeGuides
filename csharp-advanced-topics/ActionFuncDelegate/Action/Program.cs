namespace ActionDelegate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Action Delegate with the anonymous method having zero parameter and return void.
            Action actionDelegateWithZeroParameter = () =>
            {
                Console.WriteLine("Action delegate with zero parameter and return void");
            };
            actionDelegateWithZeroParameter();

            //Action Delegate with the anonymous method taking one parameter and return void.
            Action<string> actionDelegateWithOneParameter = (message) =>
            {
                Console.WriteLine(message);
            };
            actionDelegateWithOneParameter("Action delegate with one parameter and return void");

            //Action Delegate with the anonymous method taking two parameters and return void.
            Action<int, int> actionDelegateWithTwoParameters = (value1, value2) =>
            {
                Console.WriteLine($"The Action delegate can take {value1} to {value2} parameters and returns void");
            };
            actionDelegateWithTwoParameters(0, 16);
        }
    }
}