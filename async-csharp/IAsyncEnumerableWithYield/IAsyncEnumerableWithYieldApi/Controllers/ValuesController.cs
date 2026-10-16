using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IAsyncEnumerable<int> Get()
    {
        return FetchItems();
    }

    static async IAsyncEnumerable<int> FetchItems()
    {
        for (int i = 1; i <= 10; i++)
        {
            await Task.Delay(1000);
            yield return i;
        }
    }
}
