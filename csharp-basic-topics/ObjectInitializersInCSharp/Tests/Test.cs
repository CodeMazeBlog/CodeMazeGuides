using ObjectInitializersInCSharp;

namespace Tests
{
    public class Test
    {
        [Fact]
        public void WhenInitializingProduct_ThenReturnProduct()
        {
            var product = new Product
            {
                Name = "Book",
                Quantity = 15,
                UnitPrice = 17.99m
            };

            Assert.Equal("Book", product.Name);

            Assert.Equal(15, product.Quantity);

            Assert.Equal(17.99m, product.UnitPrice);
        }

        [Fact]
        public void WhenInitializingOrderWithProduct_ThenReturnOrderWithProduct()
        {
            var order = new Order
            {
                OrderId = 12345,
                OrderDate = DateTime.Now,
                Products = new List<Product>
                {
                    new Product
                    {
                        Name = "Watch",
                        Quantity = 2,
                        UnitPrice = 999.99m
                    },
                    new Product
                    {
                        Name = "Shirt",
                        Quantity = 7,
                        UnitPrice = 79.99m
                    }
                }
            };

            Assert.Equal(12345, order.OrderId);

            Assert.NotEqual(default, order.OrderDate);

            Assert.Equal(2, order.Products.Count);

            Assert.Equal("Watch", order.Products[0].Name);

            Assert.Equal(2, order.Products[0].Quantity);

            Assert.Equal(999.99m, order.Products[0].UnitPrice);

            Assert.Equal("Shirt", order.Products[1].Name);

            Assert.Equal(7, order.Products[1].Quantity);

            Assert.Equal(79.99m, order.Products[1].UnitPrice);
        }

        [Fact]
        public void WhenInitializingAnonymousPerson_ThenReturnAnonymousPerson()
        {
            var person = new
            {
                FirstName = "Charlie",
                LastName = "Brown",
                Age = 40
            };

            Assert.Equal("Charlie", person.FirstName);

            Assert.Equal("Brown", person.LastName);

            Assert.Equal(40, person.Age);
        }

        [Fact]
        public void WhenCreatingStringCollection_ThenReturnStringCollection()
        {
            var fruits = new List<string>
            {
                "apple",
                "banana",
                "cherry",
                "melon"
            };

            Assert.Equal(4, fruits.Count);

            Assert.Contains("banana", fruits);

            Assert.DoesNotContain("pineapple", fruits);
        }

        [Fact]
        public void WhenCreatingnumbers_ThenReturnnumbers()
        {
            var numbers = new Dictionary<string, int>
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 }
            };

            Assert.Equal(3, numbers.Count);

            Assert.Equal(2, numbers["two"]);

            Assert.Contains("one", numbers.Keys);

            Assert.Contains(3, numbers.Values);
        }
    }
}