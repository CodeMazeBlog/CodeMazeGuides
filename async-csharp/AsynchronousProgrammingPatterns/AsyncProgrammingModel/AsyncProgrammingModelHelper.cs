using AsynchronousProgrammingModel.Providers;
using System;

namespace AsynchronousProgrammingModel
{
    public static class AsyncProgrammingModelHelper
    {
        public static void FetchAndPrintUser(int userId)
        {
            var userProvider = new UserProvider();

            userProvider.BeginGetUser(userId, callback: (IAsyncResult asyncResult) =>
            {
                var context = (UserProvider)asyncResult.AsyncState;

                try
                {
                    var user = context.EndGetUser(asyncResult);
                    Console.WriteLine($"Id: {user.Id}\nName: {user.Name}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }, state: userProvider);
        }
    }
}
