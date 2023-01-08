using System.ComponentModel;
using Services;
using Services.Models;

namespace EventBasedAsyncPattern.Providers;

public class UserProvider
{
    //private bool _isOperationRunning = false;
    private readonly SendOrPostCallback _operationFinished;
    private readonly UserService _userService;

    public UserProvider()
    {
        _operationFinished = ProcessOperationFinished;
        _userService = new UserService();
    }

    public User GetUser(int userId) => _userService.GetUser(userId);

    public event EventHandler<GetUserCompletedEventArgs>
      GetUserCompleted;

    public void GetUserAsync(int userId, object userState)
    {
        //if (_isOperationRunning)
        //    throw new InvalidOperationException();

        //_isOperationRunning = true;
        AsyncOperation operation = AsyncOperationManager
         .CreateOperation(userState);

        // Running GetUser asynchronously
        ThreadPool.QueueUserWorkItem(state =>
        {
            GetUserCompletedEventArgs args = null;
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

            // Using AsyncOperation that will marshal control
            // flow to the synchronization context that was
            // captured at the beginning of this method.
            operation.PostOperationCompleted(_operationFinished, args);

        }, userState);
    }

    private void ProcessOperationFinished(object state)
    {
        // Mark that current operation is completed
        //_isOperationRunning = false;

        var args = (GetUserCompletedEventArgs)state;

        GetUserCompleted?.Invoke(this, args);
    }
}

public class GetUserCompletedEventArgs : AsyncCompletedEventArgs
{
    public GetUserCompletedEventArgs(
        Exception error, bool cancelled, object userState)
        : base(error, cancelled, userState)
    {
    }
}