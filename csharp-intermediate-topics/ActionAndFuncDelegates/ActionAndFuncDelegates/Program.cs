using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    class Program
    {
        delegate void OnSuccessful(string randomName);

        delegate void OnFailure(Exception ex);


        delegate string SaySomething();

        static string SayHi() { return "Hi!"; }

        static void Main(string[] args)
        {
            SaySomething methodSayHi = SayHi;
            Console.WriteLine(methodSayHi.Invoke());
        }

        //Task[] randomNameGetterTasks = new Task[10];
        //for (int i = 0; i < 10; i++)
        //{
        //    Task randomNameGetterTask = GetRandomNameAsync((randomName) => Console.WriteLine($"Random name was received successfully !: {randomName}"),
        //                                                   (exception) => Console.WriteLine($"Random name couldn't get!: {exception}"));
        //    randomNameGetterTask.Start();
        //    randomNameGetterTasks[i] = randomNameGetterTask;
        //}
        //Task.WaitAll(randomNameGetterTasks);

        private class RandomUserName
        {
            public string Title { get; set; }
            public string First { get; set; }
            public string Last { get; set; }
        }

        private class RandomUser
        {
            public RandomUserName Name { get; set; }
        }

        private class RandomUserResponse
        {
            public RandomUser[] Results { get; set; }
        }

        static Task GetRandomNameAsync(OnSuccessful onSuccessfulAction, OnFailure onFailureAction)
        {
            return new Task(() =>
            {
                try
                {
                    RandomUserResponse response = SendGetRequest<RandomUserResponse>("https://randomuser.me/api/");
                    RandomUser firstUser = response.Results.First();
                    onSuccessfulAction.Invoke($"{firstUser.Name.Title}. {firstUser.Name.First} {firstUser.Name.Last}");
                }
                catch (Exception ex)
                {
                    onFailureAction.Invoke(ex);
                }
            });
        }

        static TResponseBody SendGetRequest<TResponseBody>(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using StreamReader reader = new(response.GetResponseStream());
            return JsonConvert.DeserializeObject<TResponseBody>(reader.ReadToEnd());
        }
    }
}
