using AsynchronousProgrammingModel.Providers;
using Services.Models;
using System;

namespace AsynchronousProgrammingModel
{
    public static class AsyncProgrammingModel
    {
        public static void FetchAndPrintUser(int userId)
        {
            var userService = new UserProvider();

            // Pseudo asynchronous call
            IAsyncResult ar1 = userService.BeginGetUser(userId, callback: null, state: null);
            ar1.AsyncWaitHandle.WaitOne();
            User user = userService.EndGetUser(ar1);
            Console.WriteLine("User Name :" + user.Name);

            // With call-back
            userService.BeginGetUser(userId, callback: (IAsyncResult asyncResult) =>
            {
                var context = (UserProvider)asyncResult.AsyncState;

                try
                {
                    user = context.EndGetUser(asyncResult);
                    Console.WriteLine($"User Name : {user.Name}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }, state: userService);
        }
    }
}
