namespace WebApiReturnHttp500.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUser _userService;

    public UserController(IUser user)
    {
        _userService = user;
    }

    [HttpGet]
    [Route("GetUsersFirstMethod")]
    public IActionResult GetUsersFirstMethod()
    {
        try
        {
            // Simulating an exception by explicitly throwing it
            throw new Exception("Simulated exception");

            return Ok(_userService.GetAllUsers());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    [Route("GetUsersSecondMethod")]
    public IActionResult GetUsersSecondMethod()
    {
        try
        {
            // Simulating an exception by explicitly throwing it
            throw new Exception("Simulated exception");

            return Ok(_userService.GetAllUsers());
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet]
    [Route("GetUsersThirdMethod")]
    public IActionResult GetUsersThirdMethod()
    {
        try
        {
            // Simulating an exception by explicitly throwing it
            throw new Exception("Simulated exception");

            return Ok(_userService.GetAllUsers());
        }
        catch (Exception ex)
        {
            return new ContentResult
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Content = "An error occurred while processing the request.",
                ContentType = "text/plain"
            };
        }
    }

    [HttpGet]
    [Route("GetUsersFourthMethod")]
    public IActionResult GetUsersFourthMethod()
    {
        try
        {
            // Simulating an exception by explicitly throwing it
            throw new Exception("Simulated exception");

            return Ok(_userService.GetAllUsers());
        }
        catch (Exception ex)
        {
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Title = "Internal Server Error",
                Detail = "An error occurred while processing the request."
            };

            return new ObjectResult(problemDetails)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}