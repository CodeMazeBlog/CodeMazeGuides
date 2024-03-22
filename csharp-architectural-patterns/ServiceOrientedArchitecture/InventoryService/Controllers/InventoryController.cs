using InventoryService.Models.Contracts.Requests;
using InventoryService.Models.Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace InventoryService.Controllers
{
    public class InventoryController : ControllerBase
    {
        public async Task<GetInventoryCountByIdResponse> GetInventoryCountById(GetInventoryCountByIdRequest request)
        {
            // perform controller logic here by fetching requested data
            return await Task.Run(() => new GetInventoryCountByIdResponse()
            {
                Id = request.ItemId,
                Name = "Popping corn",
                Count = 100,
                UnitOfMeasurement = "lbs"
            });
        }
    }
}
