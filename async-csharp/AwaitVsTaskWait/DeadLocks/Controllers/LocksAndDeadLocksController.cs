using Microsoft.AspNetCore.Mvc;

namespace DeadLocks.Controllers;

[ApiController]
[Route("[controller]")]
public class LocksAndDeadLocksController : ControllerBase
{
    [HttpPost]
    public IActionResult Post()
    {
        List<int> list1 = new();
        List<int> list2 = new();

        var task1 = Task.Run(() =>
        {
            lock (list1)
            {
                Thread.Sleep(100);
                lock (list2)
                {
                    for(int i = 0; i < 5; i++)
                    {
                        list1.Add(i);
                    }
                }
            }
        });

        var task2 = Task.Run(() =>
        {
            lock (list2)
            {
                Thread.Sleep(100);
                lock (list1)
                {
                    for (int i = 6; i < 10; i++)
                    {
                        list2.Add(i);
                    }
                }
            }
        });

        task1.Wait();
        task2.Wait(); // This will cause a deadlock
        list1.AddRange(list2);
        return Ok(list1);
    }
}