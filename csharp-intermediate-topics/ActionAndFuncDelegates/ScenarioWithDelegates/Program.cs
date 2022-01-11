using System;
using System.Linq;
using System.Threading.Tasks;

namespace ScenarioWithDelegates
{
    public class Program
    {
        public delegate void OnSuccessful(string generatedRandomName);

        public delegate void OnFailure(Exception ex);

        static void CallOnSuccessful(string generatedRandomName)
        {
            Console.WriteLine($"Random name was received successfully !: {generatedRandomName}");
        }

        static void CallOnFailure(Exception exception)
        {
            Console.WriteLine($"Random name couldn't get!: {exception}");
        }

        static void Main(string[] args)
        {
            Task[] randomNameGetterTasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                Task randomNameGetterTask = CreateRandomNameGeneratorTask(CallOnSuccessful, CallOnFailure, new HttpClient());
                randomNameGetterTask.Start();
                randomNameGetterTasks[i] = randomNameGetterTask;
            }
            Task.WaitAll(randomNameGetterTasks);
        }

        public class RandomUserName
        {
            public string Title { get; set; }
            public string First { get; set; }
            public string Last { get; set; }
        }

        public class RandomUser
        {
            public RandomUserName Name { get; set; }
        }

        public class RandomUserResponse
        {
            public RandomUser[] Results { get; set; }
        }

        public static Task CreateRandomNameGeneratorTask(OnSuccessful onSuccessfulAction, OnFailure onFailureAction,
            IHttpClient httpClient)
        {
            return new Task(() =>
            {
                try
                {
                    RandomUserResponse response =
                        httpClient.SendGetRequest<RandomUserResponse>("https://randomuser.me/api/");
                    RandomUser firstUser = response.Results.First();
                    onSuccessfulAction
                        .Invoke($"{firstUser.Name.Title}. {firstUser.Name.First} " + $"{firstUser.Name.Last}");
                }
                catch (Exception ex)
                {
                    onFailureAction.Invoke(ex);
                }
            });
        }
    }
}