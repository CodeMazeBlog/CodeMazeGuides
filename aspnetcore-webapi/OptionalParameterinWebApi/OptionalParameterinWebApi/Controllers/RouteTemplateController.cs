using Microsoft.AspNetCore.Mvc;

namespace OptionalParameterinWebApi.Controllers
{
    // Each action here isolates one route template form so a test can observe what the
    // router does with it: whether the URL matches without the segment, and what the
    // action receives when it does not.
    [Route("api/[controller]")]
    [ApiController]
    public class RouteTemplateController : ControllerBase
    {
        // "?" makes the segment skippable. The router leaves the route value unset,
        // so the method default is what supplies the value.
        [HttpGet("Optional/{id?}")]
        public string Optional(int id = 1)
            => Describe(id);

        // The same template with no method default. The URL still matches and the
        // parameter silently binds to default(int).
        [HttpGet("OptionalNoDefault/{id?}")]
        public string OptionalNoDefault(int id)
            => Describe(id);

        // "=1" is a route default. The router substitutes the value before the action
        // runs, so the route value is always set.
        [HttpGet("Default/{id=1}")]
        public string Default(int id)
            => Describe(id);

        // Constraint first, "?" last. Still refuses a non-integer segment.
        [HttpGet("ConstrainedOptional/{id:int?}")]
        public string ConstrainedOptional(int id = 1)
            => Describe(id);

        // A constraint and a route default in one segment, constraint first.
        [HttpGet("ConstrainedDefault/{id:int=1}")]
        public string ConstrainedDefault(int id)
            => Describe(id);

        private string Describe(int id)
            => $"id={id};routeValueSet={RouteData.Values.ContainsKey("id")}";
    }
}
