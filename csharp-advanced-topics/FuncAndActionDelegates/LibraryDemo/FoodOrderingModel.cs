using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDemo
{
    public class FoodOrderingModel
    {
        public List<OrderItemModel> Items { get; set; }=new List<OrderItemModel>();
        public decimal GenerateBill(Func<List<OrderItemModel>,decimal,decimal> ComputeDiscount,Action<decimal> NotifyToUser)
        {
            decimal OrderPrice = GetSumPrice(Items);
            NotifyToUser(OrderPrice);
            return ComputeDiscount(Items, OrderPrice);
        }

        public decimal GetSumPrice(List<OrderItemModel> items)
        {
            if (items != null)
                return items.Sum(x => x.Price);
            else
                throw new ArgumentNullException("OrderItemList");
        }
    }
}
