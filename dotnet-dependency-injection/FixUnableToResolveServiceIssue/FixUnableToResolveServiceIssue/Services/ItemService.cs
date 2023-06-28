using FixUnableToResolveServiceIssue.Interfaces;
using FixUnableToResolveServiceIssue.Models;

namespace FixUnableToResolveServiceIssue.Services
{
    public class ItemService : IItemService
    {
        public Item GetItem()
        {
            return new Item
            {
                Id = 1,
                Name = "Code Maze",
                Description = "Code Maze Item!"
            };
        }
    }
}
