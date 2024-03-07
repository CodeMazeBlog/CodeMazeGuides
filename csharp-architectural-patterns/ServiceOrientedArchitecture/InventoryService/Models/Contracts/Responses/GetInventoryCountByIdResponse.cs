namespace InventoryService.Models.Contracts.Responses
{
    public sealed class GetInventoryCountByIdResponse
    {
        public List<Guid> SearchResults { get; } = new();
    }
}
