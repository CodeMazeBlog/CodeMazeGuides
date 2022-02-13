
using ActionAndFuncDemo.BusinessModels;
using ActionAndFuncDemo.BusinessProcesses;
///This demo shows the use of action and func delegates into our business use case
///Case: We are building a items check-out in which the user will get discounts on shopping
///Though we are not taking inputs from the user in order to keep the focus on main purpose i.e. The Use of Action and Func Delegates


//We are setting up items into a list (Real-world secnario: Items stored into the database)
List<Item> items = new();
items.Add(new Item(1, "Apples", 4.3m, 20m, Metrics.Kg));
items.Add(new Item(2, "Mangoes", 0.53m, 200m, Metrics.Unit));
items.Add(new Item(3, "Pineapple", 2.28m, 150m, Metrics.Unit));
items.Add(new Item(4, "Kiwi", 2.24m, 48m, Metrics.Lb));
items.Add(new Item(5, "Strawberries", 4.74m, 103m, Metrics.Lb));


/* Case: 
 * We have some requirements.
 * The store owner wants to give discounts based upon the grand total.
 * The owner says, we want to give the discount of 30% on the bill of more than $25.
 * Similarly, want to give 20% discount on more than $20, 10% on more than $15 and 5% on more than $10 respectively.
 * There would be no discount on less than $10.
 * Now, lets see what happens when the customer came to purchase, selected some items and proceed to checkout 
 */

var cartItems = new List<CartItem>();
var item = items.FirstOrDefault(x => x.Id == 1); //selected some apples
if (item is not null)
{
    //added 3 kgs (which is currently the metric) of apples into the cart 
    cartItems.Add(new CartItem(item.Id, item.Name, item.Price, 3, item.Metric));
}
item = items.FirstOrDefault(x => x.Id == 2); //selected some mangoes
if (item is not null)
{
    //added 6 units (which is currently the metric) of manges into the cart 
    cartItems.Add(new CartItem(item.Id, item.Name, item.Price, 6, item.Metric));
}
item = items.FirstOrDefault(x => x.Id == 4); //selected some kiwi
if (item is not null)
{
    //added 4.3 lb (which is currently the metric) of kiwi into the cart 
    cartItems.Add(new CartItem(item.Id, item.Name, item.Price, 4.3m, item.Metric));
}
//Now, we are proceeding to check-out
var checkOutProcess = new CheckoutProcess();

//Creating the cart
checkOutProcess.CreateCart(cartItems, DiscountProcesses.CalculateDiscount); //generating the cart


//Displaying the cart
checkOutProcess.DisplayCart(DisplayProcesses.DisplayCart);
