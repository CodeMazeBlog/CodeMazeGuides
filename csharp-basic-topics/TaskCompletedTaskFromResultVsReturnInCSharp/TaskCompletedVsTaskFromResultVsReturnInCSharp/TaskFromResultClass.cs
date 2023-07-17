namespace TaskCompletedVsTaskFromResultVsReturnInCSharp
{
    public class TaskFromResultClass
    {
        public async Task<string> UseTaskFromResultMethodAsync()
        {
            Console.WriteLine($"I am in {nameof(UseTaskFromResultMethodAsync)} method. Not performing any asynchronous work but returning a result.");

            string message = "Hello, world!";

            // Return a completed Task with a result
            return await Task.FromResult(message);
        }
    }
}