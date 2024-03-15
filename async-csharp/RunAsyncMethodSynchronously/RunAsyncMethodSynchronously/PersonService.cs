using System;

namespace RunAsyncMethodSynchronously;

public class PersonService
{
    public List<Person> GetPeople()
    {
        var task = new Task<List<Person>>(() =>
        {
            Thread.Sleep(200);

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
        await Task.Delay(200);

        return new List<Person>
        {
            new() { Name = "Alice", Age = 25 },
            new() { Name = "Bob", Age = 30 },
            new() { Name = "Charlie", Age = 35 }
        };
    }

    public async Task ThrowExceptionAsync()
    {
        await Task.Delay(200);

        throw new InvalidOperationException("The task threw an invalid operation exception");
    }

    public void ExceptionHandlingUsingWaitMethod()
    {
        var task = ThrowExceptionAsync();
        try
        {
            task.Wait();
        }
        catch (AggregateException e)
        {
            foreach (var innerException in e.InnerExceptions)
            {
                Console.WriteLine(innerException.Message);
                throw;
            }
        }
    }

    public void ExceptionHandlingUsingGetAwaiterMethod()
    {
        var task = ThrowExceptionAsync();
        try
        {
            task.GetAwaiter().GetResult();
        }
        catch (InvalidOperationException e)
        {
            Console.WriteLine($"Error Message: {e.Message}");
            throw;
        }
    }
}
