using System.Net;
using System.Text;

namespace SimpleHTTPServer;

public class ChunkUploadServer
{
	readonly int chunkSize;
	readonly int threadCount;

	public ChunkUploadServer(int chunkSize, int threadCount)
	{
		this.chunkSize = chunkSize;
		this.threadCount = threadCount;
	}

	public async Task StartServer(int port)
	{
		var uri = $"http://localhost:{port}/upload/";

		var listener = new HttpListener();
		listener.Prefixes.Add(uri);
		listener.Start();

		Console.WriteLine($"Server started listening at {uri}");

		// Wait for a client request
		var context = await listener.GetContextAsync();
		if (context.Request.HttpMethod == HttpMethod.Post.Method)
		{
			await ProcessUpload(context);
		}
		else
		{
			context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
			context.Response.Close();
		}
	}

	public async Task ProcessUpload(HttpListenerContext context)
	{
		// Get the name of the file being uploaded from the request
		var fileName = Path.GetFileName(context.Request.Headers["X-Filename"]);

		//  If the file size is larger than total chunk size, handle appropriately
		if (context.Request.ContentLength64 > chunkSize * threadCount)
		{
			Console.WriteLine("File size exceeds chunk capacity.");
			context.Response.Abort();
			return;
		}

		var barrier = new Barrier(threadCount + 1);

		for (int i = 0; i < threadCount; i++)
		{
			int chunkNumber = i + 1;
			var threadTask = Task.Run(() =>
			{
				var buffer = new byte[chunkSize];

				int bytesRead = context.Request.InputStream.Read(buffer, 0, buffer.Length);
				if (bytesRead > 0)
				{
					// Logic to process the chunk
					Console.WriteLine($"Thread {chunkNumber} processed {bytesRead} bytes of chunk {chunkNumber}.");
				}

				barrier.SignalAndWait();
			});
		}

		barrier.SignalAndWait();

		// Respond to request
		var message = $"File '{fileName}' uploaded successfully...";

		context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(message);
		context.Response.StatusCode = (int)HttpStatusCode.Created;

		using (Stream s = context.Response.OutputStream)
		using (StreamWriter writer = new StreamWriter(s))
			await writer.WriteAsync(message);
	}
}