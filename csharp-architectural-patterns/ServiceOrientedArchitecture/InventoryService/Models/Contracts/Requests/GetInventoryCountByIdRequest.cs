namespace InventoryService.Models.Contracts.Requests
{
    public sealed class GetInventoryCountByIdRequest
    {
        public string ItemId { get; set; } = "";
    }
}
