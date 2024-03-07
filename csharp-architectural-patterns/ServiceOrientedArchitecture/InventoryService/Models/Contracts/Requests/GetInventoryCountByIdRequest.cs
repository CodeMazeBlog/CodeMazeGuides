namespace InventoryService.Models.Contracts.Requests
{
    public sealed class GetInventoryCountByIdRequest
    {
        public Guid ItemId { get; } = Guid.NewGuid();
    }
}
