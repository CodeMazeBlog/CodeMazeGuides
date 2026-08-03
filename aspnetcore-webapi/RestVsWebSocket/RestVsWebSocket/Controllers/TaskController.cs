using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Net;
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
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var ws = await HttpContext.WebSockets.AcceptWebSocketAsync();

            while (true)
            {
                var message = "The time is: " + DateTime.Now.ToString("HH:mm:ss");
                var bytes = Encoding.UTF8.GetBytes(message);
                var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
                if (ws.State == WebSocketState.Open)
                {
                    await ws.SendAsync(arraySegment,
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None);
                }
                else if (ws.State == WebSocketState.Closed || ws.State == WebSocketState.Aborted)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
        }
        else
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}