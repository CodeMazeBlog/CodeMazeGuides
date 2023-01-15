using AsynchronousProgrammingPatterns.Providers;
using System.Text;

namespace AsynchronousProgrammingPatterns;

public static class AsyncProgrammingModelHelper
{
    public static void FetchAndPrintUser(int userId)
    {

        var apmUserProvider = new ApmUserProvider();

        apmUserProvider.BeginGetUser(userId, callback: (asyncResult) =>
        {
            var context = asyncResult.AsyncState as ApmUserProvider;
            try
            {
                var fileContentBuffer = context?.EndGetUser(asyncResult);

                Console.WriteLine(Encoding.UTF8.GetString(fileContentBuffer!));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }, state: apmUserProvider);
    }
}
