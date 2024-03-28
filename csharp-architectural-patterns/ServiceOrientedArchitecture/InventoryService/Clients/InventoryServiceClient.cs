using InventoryService.Models;
using InventoryService.Models.Contracts.Requests;
using InventoryService.Models.Contracts.Responses;

namespace InventoryService.Clients
{
    public class InventoryServiceClient : IInventoryServiceClient
    {
        public Task<bool> AddItemToInventory(InventoryItem itemObj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemFromInventory(string itemId)
        {
            throw new NotImplementedException();
        }

        public Task<GetInventoryCountByIdResponse> GetInventoryItemById(GetInventoryCountByIdRequest id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IncreaseItemInventoryCount(string itemId, int amountToIncrease)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ReduceItemInventoryCount(string itemId, int amountToReduce)
        {
            throw new NotImplementedException();
        }
    }
}
