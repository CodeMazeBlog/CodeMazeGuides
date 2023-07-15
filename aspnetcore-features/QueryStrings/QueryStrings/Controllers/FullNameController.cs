using Microsoft.AspNetCore.Mvc;

namespace QueryStrings.Controllers;

/// <summary>
/// Full Name API controller to demonstrate the use of Query Strings
/// </summary>
[ApiController]
[Route("[controller]")]
public class FullNameController : ControllerBase
{
    [HttpGet(template: "/v1", Name = "GetQueryStringsAsScalarValues")]
    public IActionResult GetFullNameFromScalarValues([FromQuery] string firstName, [FromQuery] string lastName)
    {
        return Ok(new { FullName = $"{firstName} {lastName}" });
    }

    [HttpGet(template: "/v2", Name = "GetMultipleQueryStringsAsArray")]
    public IActionResult GetProductsByIds([FromQuery] int[] ids)
    {
        return Ok(new { ProductIds = ids });
    }

    [HttpGet("/v3", Name = "GetMultipleQueryStringsAsObject")]
    public IActionResult GetFullNameFromObject([FromQuery] Person queryStringParameters)
    {
        return Ok(new { FullName = $"{queryStringParameters.FirstName} {queryStringParameters.LastName}" });
    }
}

public record Person(string FirstName, string LastName);