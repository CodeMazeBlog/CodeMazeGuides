using System;

namespace ActionFunc
{
    public class Cart
    {
        public Action<string> AddProduct;
        public Func<string, string> GetReceipt;

        public void Add(string item)
        {
            AddProduct(item);
        }

        public string GetReceiptDetails(string customer)
        {
            var receipt = GetReceipt(customer);
            return receipt;
        }
    }
}
