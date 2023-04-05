namespace RunAsyncMethodSynchronously;

public class PersonService
{
    public List<Person> GetPeople()
    {
        var task = new Task<List<Person>>(() =>
        {
            Thread.Sleep(5000);

            return new List<Person>
            {
                new() { Name = "Alice", Age = 25 },
                new() { Name = "Bob", Age = 30 },
                new() { Name = "Charlie", Age = 35 }
            };
        });

        task.RunSynchronously();
        
        return task.Result;
    }
    
    public List<Person> GetPeopleUsingWaitMethod()
    {
        var task = GetPeopleAsync();
        task.Wait();

        return task.Result;
    }

    public List<Person> GetPeopleUsingResultMethod()
    {
        var task = GetPeopleAsync();

        return task.Result;
    }

    public List<Person> GetPeopleUsingGetAwaiter()
    {
        var response = GetPeopleAsync().GetAwaiter().GetResult();

        return response;
    }

    private async Task<List<Person>> GetPeopleAsync()
    {
        await Task.Delay(2000);

        return new List<Person>
        {
            new() { Name = "Alice", Age = 25 },
            new() { Name = "Bob", Age = 30 },
            new() { Name = "Charlie", Age = 35 }
        };
    }
}
