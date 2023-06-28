using FixUnableToResolveServiceIssue.Interfaces;
using FixUnableToResolveServiceIssue.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FixUnableToResolveServiceIssue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        //This is a valid dependency injection.
        public ItemController(IItemService itemService) 
        {
            _itemService = itemService;
        }

        //calling this endpoint will respond with a 200 OK response as expected.
        [HttpGet]
        public ActionResult Get()
        {
            var item = _itemService.GetItem();
            return Ok(item);
        }
    }
}
