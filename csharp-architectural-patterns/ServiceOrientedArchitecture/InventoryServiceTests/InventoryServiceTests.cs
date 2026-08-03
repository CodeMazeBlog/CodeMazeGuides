using InventoryService.Controllers;
using InventoryService.Models.Contracts.Requests;
using InventoryService.Models.Contracts.Responses;

namespace InventoryServiceTests
{
    [TestClass]
    public class InventoryServiceTests
    {
        [TestMethod]
        public async Task WhenGetInventoryCountByIdIsInvoked_ThenResponseIsReturned()
        {
            var controller = new InventoryController();

            var request = new GetInventoryCountByIdRequest() { ItemId = "G3424869540" };

            var response = await controller.GetInventoryCountById(request);

            Assert.IsNotNull(response);
            Assert.IsInstanceOfType<GetInventoryCountByIdResponse>(response);
            Assert.IsTrue(response.Count > 0);
        }
    }
}