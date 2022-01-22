using Delegates;

var demoMethods = new DemoMethods();

//Create delegate object
AwesomeCalculator awesomeCalculator = new AwesomeCalculator(demoMethods.CalculateFinalTotal);

Action<List<Product>> totalBeforDiscountee = demoMethods.DisplayTotalBeforDiscount;

List<Product> products = new List<Product>() {
                new Product()
                {
                    Id = 1,
                    Label = "Backpack",
                    Price = 50
                },
                new Product()
                {
                    Id = 2,
                    Label = "Bluetooth Headset",
                    Price = 89
                }
            };

totalBeforDiscountee(products);

//Console.WriteLine($"The total of your orders: {demoMethods.CalculateClientOrdersTotal(awesomeCalculator, products):C2}");
Console.WriteLine($"The total of your orders: {demoMethods.CalculateClientOrdersTotal2(demoMethods.CalculateFinalTotal, products):C2}");