using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;

namespace RestVsWebSocket.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    public IList<string> Tasks { get; set; }

    public TaskController()
    {
        Tasks = new List<string>();
    }

    //REST
    [HttpPost]
    public IActionResult AddTask([FromBody] string task)
    {
        if (string.IsNullOrEmpty(task))
        {
            return BadRequest("Enter valid data.");
        }

        Tasks.Add(task);

        return Ok("Task added successfully.");
    }

    //WebSocket
    [Route("/ws")]
    [HttpGet]
    public async Task Get()
    {
        using var ws = await HttpContext.WebSockets.AcceptWebSocketAsync();

        while (ws.State == WebSocketState.Open)
        {
            var message = $"The time is: {DateTime.Now:HH:mm:ss}";
            var bytes = Encoding.UTF8.GetBytes(message);

            await ws.SendAsync(bytes, WebSocketMessageType.Text, true, CancellationToken.None);
            await Task.Delay(1000);
        }
    }
}