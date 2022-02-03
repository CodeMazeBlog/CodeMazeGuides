
using ActionAndFuncDemo.BusinessModels;
using ActionAndFuncDemo.BusinessProcesses;
///This demo shows the use of action and func delegates into our business use case
///Case: We are building a items check-out in which the user will get discounts on shopping
///Though we are not taking inputs from the user in order to keep the focus on main purpose i.e. The Use of Action and Func Delegates


//We are setting up items into a list (Real-world secnario: Items stored into the database)
List<Item> items = new();
items.Add(new Item(1, "Apples", 4.3m, 20m));
items.Add(new Item(2, "Mangoes", 0.53m, 200m));
items.Add(new Item(3, "Pineapple", 2.28m, 150m));
items.Add(new Item(4, "Kiwi", 2.24m, 48m));
items.Add(new Item(5, "Strawberries", 4.74m, 103m));

/* Case 1: 
 * The customer came up to purchase, selected some items and proceed to checkout 
 */
Console.WriteLine("|----------------------------Case 1------------------------------|");
List<CartItem> cartItems = new();
var item = items.FirstOrDefault(x => x.Id == 1); //selected some apples
if (item is not null)
{
    //added 3 kgs (which is currently the metric) of apples into the cart 
    cartItems.Add(new CartItem(item.Id, item.Price, 3));
}
item = items.FirstOrDefault(x => x.Id == 3); //selected some pineapples
if (item is not null)
{
    //added 1 unit (which is currently the metric) of pineapple into the cart 
    cartItems.Add(new CartItem(item.Id, item.Price, 1));
}
item = items.FirstOrDefault(x => x.Id == 4); //selected some kiwi
if (item is not null)
{
    //added 4.3 lb (which is currently the metric) of kiwi into the cart 
    cartItems.Add(new CartItem(item.Id, item.Price, 4.3m));
}
//Now, we are proceeding to check-out
var cart = CheckoutProcess.CreateCart(cartItems, "Joe Denly"); //generating the cart

Console.WriteLine($"Customer Name: {cart.CustomerName}");
Console.WriteLine("---------------------------------------------");
foreach (var purchasedItem in cart.CartItems)
{
    Console.WriteLine($"Item Name: {items?.FirstOrDefault(x => x.Id == purchasedItem.ItemId)?.Name}");
    Console.WriteLine($"Price: ${purchasedItem.PurchasedPrice}");
    Console.WriteLine($"Quantity: {purchasedItem.PurchasedQuantity}");
    Console.WriteLine("--");
}
Console.WriteLine("---------------------------------------------");
Console.WriteLine($"G.Total:{cart.GrandTotal}");

/* Case 2: 
 * Now, we have a change in requirements.
 * The store owner wants to give discounts based upon the grand total.
 * The owner says, we want to give the discount of 30% on the bill of more than $25.
 * Similarly, want to give 20% discount on more than $20, 10% on more than $15 and 5% on more than $10 respectively.
 * There would be no discount on less than $10.
 * Now, lets see what happens when the customer came to purchase, selected some items and proceed to checkout 
 */
Console.WriteLine("|----------------------------Case 2------------------------------|");
cartItems = new();
item = items.FirstOrDefault(x => x.Id == 1); //selected some apples
if (item is not null)
{
    //added 3 kgs (which is currently the metric) of apples into the cart 
    cartItems.Add(new CartItem(item.Id, item.Price, 3));
}
item = items.FirstOrDefault(x => x.Id == 2); //selected some mangoes
if (item is not null)
{
    //added 6 units (which is currently the metric) of manges into the cart 
    cartItems.Add(new CartItem(item.Id, item.Price, 6));
}
item = items.FirstOrDefault(x => x.Id == 4); //selected some kiwi
if (item is not null)
{
    //added 4.3 lb (which is currently the metric) of kiwi into the cart 
    cartItems.Add(new CartItem(item.Id, item.Price, 4.3m));
}
//Now, we are proceeding to check-out
cart = CheckoutProcess.CreateCart(cartItems, "Jonathan Straw", DiscountProcesses.CalculateDiscount); //generating the cart

Console.WriteLine($"Customer Name: {cart.CustomerName}");
Console.WriteLine("---------------------------------------------");
foreach (var purchasedItem in cart.CartItems)
{
    Console.WriteLine($"Item Name: {items?.FirstOrDefault(x => x.Id == purchasedItem.ItemId)?.Name}");
    Console.WriteLine($"Price: ${purchasedItem.PurchasedPrice}");
    Console.WriteLine($"Quantity: {purchasedItem.PurchasedQuantity}");
    Console.WriteLine("--");
}
Console.WriteLine("---------------------------------------------");
Console.WriteLine($"G.Total:{cart.GrandTotal}");

/*
 * The Func Delegates can also be used with anonymous functions e.g.
 */

cartItems = new();
item = items.FirstOrDefault(x => x.Id == 1); //selected some apples
if (item is not null)
{
    //added 6 kgs (which is currently the metric) of apples into the cart 
    cartItems.Add(new CartItem(item.Id, item.Price, 6));
}
item = items.FirstOrDefault(x => x.Id == 2); //selected some pineapples
if (item is not null)
{
    //added 3 unit (which is currently the metric) of pineapple into the cart 
    cartItems.Add(new CartItem(item.Id, item.Price, 3));
}
item = items.FirstOrDefault(x => x.Id == 5); //selected some strawberries
if (item is not null)
{
    //added 5.4 lb (which is currently the metric) of kiwi into the cart 
    cartItems.Add(new CartItem(item.Id, item.Price, 5.4m));
}
//Now, we are proceeding to check-out
cart = CheckoutProcess.CreateCart(cartItems, "Adam Gilbert", x =>
{
    //anonymous method to calculate discount
    decimal discount = 0.0m;
    if (cart.GrandTotal >= 25)
    {
        discount = cart.GrandTotal * 0.3m;
    }
    else if (cart.GrandTotal >= 20)
    {
        discount = cart.GrandTotal * 0.2m;
    }
    else if (cart.GrandTotal >= 15)
    {
        discount = cart.GrandTotal * 0.1m;
    }
    else if (cart.GrandTotal >= 10)
    {
        discount = cart.GrandTotal * 0.05m;
    }
    return decimal.Round(discount, 2);
}); //generating the cart

Console.WriteLine($"Customer Name: {cart.CustomerName}");
Console.WriteLine("---------------------------------------------");
foreach (var purchasedItem in cart.CartItems)
{
    Console.WriteLine($"Item Name: {items?.FirstOrDefault(x => x.Id == purchasedItem.ItemId)?.Name}");
    Console.WriteLine($"Price: ${purchasedItem.PurchasedPrice}");
    Console.WriteLine($"Quantity: {purchasedItem.PurchasedQuantity}");
    Console.WriteLine("--");
}
Console.WriteLine("---------------------------------------------");
Console.WriteLine($"G.Total:{cart.GrandTotal}");

/* Case 3: 
 * Now, we have another change in requirements.
 * This time the store owner wants to add feature that deducts the quantity from the original stock
 * Now let see what happens when the customer came up to purchase, selected some items and proceed to checkout 
 */
Console.WriteLine("|----------------------------Case 3------------------------------|");

cartItems = new();
item = items.FirstOrDefault(x => x.Id == 1); //selected some apples
if (item is not null)
{
    //added 6 kgs (which is currently the metric) of apples into the cart 
    cartItems.Add(new CartItem(item.Id, item.Price, 6));
}
item = items.FirstOrDefault(x => x.Id == 2); //selected some pineapples
if (item is not null)
{
    //added 3 unit (which is currently the metric) of pineapple into the cart 
    cartItems.Add(new CartItem(item.Id, item.Price, 3));
}
item = items.FirstOrDefault(x => x.Id == 5); //selected some strawberries
if (item is not null)
{
    //added 5.4 lb (which is currently the metric) of kiwi into the cart 
    cartItems.Add(new CartItem(item.Id, item.Price, 5.4m));
}
//Now, we are proceeding to check-out
cart = CheckoutProcess.CreateCart(cartItems, "Adam Gilbert", DiscountProcesses.CalculateDiscount, x =>
{
    items.FirstOrDefault(i => i.Id == x.ItemId).Quantity -= x.PurchasedQuantity;
}); //generating the cart

Console.WriteLine($"Customer Name: {cart.CustomerName}");
Console.WriteLine("---------------------------------------------");
foreach (var purchasedItem in cart.CartItems)
{
    Console.WriteLine($"Item Name: {items?.FirstOrDefault(x => x.Id == purchasedItem.ItemId)?.Name}");
    Console.WriteLine($"Price: ${purchasedItem.PurchasedPrice}");
    Console.WriteLine($"Quantity: {purchasedItem.PurchasedQuantity}");
    Console.WriteLine("--");
}
Console.WriteLine("---------------------------------------------");
Console.WriteLine($"G.Total:{cart.GrandTotal}");