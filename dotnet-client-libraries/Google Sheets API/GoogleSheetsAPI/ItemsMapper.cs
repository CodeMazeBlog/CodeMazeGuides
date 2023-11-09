using System.Collections.Generic;

namespace GoogleSheetsAPI
{
    public static class ItemsMapper
    {
        public static List<Item> MapFromRangeData(IList<IList<object>> values)
        {
            var items = new List<Item>();

            foreach (var value in values)
            {
                Item item = new()
                {
                    Id = value[0].ToString(),
                    Name = value[1].ToString(),
                    Category = value[2].ToString(),
                    Price = value[3].ToString()
                };

                items.Add(item);
            }

            return items;
        }

        public static IList<IList<object>> MapToRangeData(Item item)
        {
            var objectList = new List<object>() { item.Id, item.Name, item.Category, item.Price };
            var rangeData = new List<IList<object>> { objectList };
            return rangeData;
        }
    }
}
