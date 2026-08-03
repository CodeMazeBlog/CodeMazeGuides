namespace InventoryService.Models.Contracts.Responses
{
    public sealed class GetInventoryCountByIdResponse
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int Count { get; set; } = 0;
        public string UnitOfMeasurement { get; set; } = "";
    }
}
