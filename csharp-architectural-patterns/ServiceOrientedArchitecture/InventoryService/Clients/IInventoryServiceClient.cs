using InventoryService.Models;
using InventoryService.Models.Contracts.Requests;
using InventoryService.Models.Contracts.Responses;

namespace InventoryService.Clients
{
    public interface IInventoryServiceClient
    {
        Task<GetInventoryCountByIdResponse> GetInventoryItemById(GetInventoryCountByIdRequest id);
        Task<bool> AddItemToInventory(InventoryItem itemObj);
        Task<bool> DeleteItemFromInventory(string itemId);
        Task<bool> ReduceItemInventoryCount(string itemId, int amountToReduce);
        Task<bool> IncreaseItemInventoryCount(string itemId, int amountToIncrease);
    }
}
