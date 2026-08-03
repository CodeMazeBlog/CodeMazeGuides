namespace DictionaryInCsharp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var dict1 = new Dictionary<int, string>();

            var dict2 = new Dictionary<int, string>(10);

            var dict3 = new Dictionary<int, string>()
            {
                {1, "Red"},
                {2, "Yellow"},
                {3, "Green"},
            };

            var color = (dict3.GetValueOrDefault(4, "Color not found."));
            Console.WriteLine(color);

            var productsDict = CreateDictionary();

            AddToDictionary(productsDict);
            Console.WriteLine();

            RetrieveDictionaryElements(productsDict);
            Console.WriteLine();

            UpdateDictionary(productsDict);
            Console.WriteLine();

            DeleteDictionaryElements(productsDict);
            Console.WriteLine();

            ClearDictionary(productsDict);
            Console.WriteLine();
        }
        public static Dictionary<int, Product> CreateDictionary()
        {
            var productsDict = new Dictionary<int, Product>();

            return productsDict;
        }

        public static Dictionary<int, Product> AddToDictionary(Dictionary<int, Product> productsDict)
        {
            productsDict.Add(0, new Product() { ProductId = 111, ProductName = "Table" });
            productsDict.Add(1, new Product() { ProductId = 112, ProductName = "Chair" });
            productsDict.Add(2, new Product() { ProductId = 113, ProductName = "TV" });

            try
            {
                productsDict.Add(2, new Product() { ProductId = 113, ProductName = "Wardrobe" });
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (productsDict.TryAdd(3, new Product() { ProductId = 114, ProductName = "Lamp" }))
            {
                Console.WriteLine($"Product is added.");
            }

            return productsDict;
        }

        public static Product? RetrieveDictionaryElements(Dictionary<int, Product> productsDict)
        {
            foreach (KeyValuePair<int, Product> product in productsDict)
            {
                Console.WriteLine($"Key = {product.Key}, Value = {product.Value.ProductId}, {product.Value.ProductName}");
            }

            if (productsDict.TryGetValue(2, out Product? product1) && product1 != null)
            {
                Console.WriteLine($"Key = {2} exists, Value = {product1.ProductId}, {product1.ProductName}");
            }

            var productValue = (productsDict.GetValueOrDefault(1));

            if (productValue != null)
            {
                Console.WriteLine($"Key = {1} exists, Value = {productValue.ProductId}, {productValue.ProductName}");
            }

            return productValue;
        }

        public static Dictionary<int, Product> UpdateDictionary(Dictionary<int, Product> productsDict)
        {
            productsDict[0] = new Product() { ProductId = 110, ProductName = "Desk" };

            foreach (KeyValuePair<int, Product> product in productsDict)
            {
                Console.WriteLine($"Key = {product.Key}, Value = {product.Value.ProductId}, {product.Value.ProductName}");
            }

            return productsDict;
        }

        public static Dictionary<int, Product> DeleteDictionaryElements(Dictionary<int, Product> productsDict)
        {
            productsDict.Remove(2);

            foreach (KeyValuePair<int, Product> product in productsDict)
            {
                Console.WriteLine($"Key = {product.Key}, Value = {product.Value.ProductId}, {product.Value.ProductName}");
            }

            return productsDict;
        }

        public static int ClearDictionary(Dictionary<int, Product> productsDict)
        {
            productsDict.Clear();

            var numberOfElements = productsDict.Count;

            Console.WriteLine($"Number of dictionary elements: {numberOfElements}");

            return numberOfElements;
        }
    }
}
