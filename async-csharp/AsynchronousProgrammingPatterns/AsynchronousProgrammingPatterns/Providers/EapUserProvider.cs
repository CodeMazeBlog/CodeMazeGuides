using AsynchronousProgrammingPatterns.Services;
using AsynchronousProgrammingPatterns.Services.Models;
using System.ComponentModel;

namespace AsynchronousProgrammingPatterns.Providers;

public class EapUserProvider
{
    private readonly SendOrPostCallback _operationFinished;
    private readonly UserService _userService;

    public EapUserProvider()
    {
        _operationFinished = ProcessOperationFinished;
        _userService = new UserService();
    }

    public User GetUser(int userId) => _userService.GetUser(userId);

    public event EventHandler<GetUserCompletedEventArgs> GetUserCompleted;

    public void GetUserAsync(int userId) => GetUserAsync(userId, null);

    public void GetUserAsync(int userId, object userState)
    {
        AsyncOperation operation = AsyncOperationManager.CreateOperation(userState);

        ThreadPool.QueueUserWorkItem(state =>
        {
            GetUserCompletedEventArgs args;
            try
            {
                var user = GetUser(userId);
                args = new GetUserCompletedEventArgs(null, false, user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                args = new GetUserCompletedEventArgs(e, false, null);
            }

            operation.PostOperationCompleted(_operationFinished, args);

        }, userState);
    }

    private void ProcessOperationFinished(object state)
    {
        var args = (GetUserCompletedEventArgs)state;

        GetUserCompleted?.Invoke(this, args);
    }
}

public class GetUserCompletedEventArgs : EventArgs
{
    public Exception Error { get; }
    public bool Cancelled { get; }
    public User User { get; }

    public GetUserCompletedEventArgs(Exception error, bool cancelled, User user)
    {
        Error = error;
        Cancelled = cancelled;
        User = user;
    }
}
