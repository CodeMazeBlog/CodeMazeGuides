using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoFuncDelegate
{
    public class Item
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
    }
    public class CalculateDiscount
    {
        public List<Item> Items { get; set; } = new List<Item>();

        public decimal CalculateItemDiscount(Func<List<Item>,decimal,decimal> calculateDiscountedItem, Action<string> discountMessage )
        {
            decimal subTotal = Items.Sum(x => x.ItemPrice);
            discountMessage($"Applying discount.");
            return calculateDiscountedItem(Items,subTotal);
        }
    }

    class Program
    {
        static CalculateDiscount item = new CalculateDiscount();
        static void Main(string[] args)
        {
            PopulateItemData();

            decimal total = item.CalculateItemDiscount((items, itemTotal) => {
                if (items.Select(p=> p.ItemPrice).Sum()>=5.00M)
                {
                    return itemTotal * 0.25M; 
                }
                else
                {
                    return itemTotal * 0.10M;
                }

            }, 
            (message)=> Console.WriteLine(message));

            Console.WriteLine($"The total discount {total}");
            Console.ReadKey();
        }

        private static void PopulateItemData()
        {
            item.Items.Add(new Item { ItemName = "Rice", ItemPrice = 1.63M });
            item.Items.Add(new Item { ItemName = "Meat", ItemPrice = 2.95M });
            item.Items.Add(new Item { ItemName = "Mango", ItemPrice = 4.51M });
            item.Items.Add(new Item { ItemName = "Banana", ItemPrice = 4.84M });
        }

    }
}
