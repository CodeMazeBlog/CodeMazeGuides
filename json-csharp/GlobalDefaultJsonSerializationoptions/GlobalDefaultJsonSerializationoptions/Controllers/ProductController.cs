using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GlobalDefaultJsonSerializationoptions.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    [HttpPost]
    public ActionResult CreateProduct(Product product)
    {
        return Ok(product);
    }

    [HttpPost("save")]
    public ActionResult SaveProduct(Product product)
    {
        return Ok(JsonConvert.SerializeObject(product));
    }
}
