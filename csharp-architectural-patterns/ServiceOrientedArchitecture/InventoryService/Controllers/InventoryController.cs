using InventoryService.Models.Contracts.Requests;
using InventoryService.Models.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Controllers
{
    public class InventoryController : ControllerBase
    {
        public Task<GetInventoryCountByIdResponse> GetInventoryCountById(GetInventoryCountByIdRequest request)
        {
            // perform controller logic here by fetching requested data
            return Task.FromResult(new GetInventoryCountByIdResponse()
            {
                Id = request.ItemId,
                Name = "Popping corn",
                Count = 100,
                UnitOfMeasurement = "lbs"
            });
        }
    }
}
