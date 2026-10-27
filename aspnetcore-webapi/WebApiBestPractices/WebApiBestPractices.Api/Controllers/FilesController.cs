using Microsoft.AspNetCore.Mvc;

namespace WebApiBestPractices.Api.Controllers;

[ApiController]
[Route("api/files")]
public class FilesController(IConfiguration configuration) : ControllerBase
{
    [HttpPost]
    [RequestSizeLimit(10 * 1024 * 1024)]
    public async Task<IActionResult> Upload(CancellationToken cancellationToken)
    {
        var formCollection = await Request.ReadFormAsync(cancellationToken);
        var file = formCollection.Files.FirstOrDefault();
        if (file is null || file.Length == 0)
            return BadRequest("No file was uploaded.");

        var folder = configuration["Uploads:Path"] ?? "Uploads";
        Directory.CreateDirectory(folder);

        // Never trust the client's file name: generate our own.
        var fileName = Path.GetRandomFileName();
        await using var stream = System.IO.File.Create(Path.Combine(folder, fileName));
        await file.CopyToAsync(stream, cancellationToken);

        return Ok(new { fileName });
    }
}
