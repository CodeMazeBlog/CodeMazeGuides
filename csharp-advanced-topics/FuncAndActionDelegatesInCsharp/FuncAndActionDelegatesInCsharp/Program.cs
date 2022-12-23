public class Program
{
    //1. delegates

    //1.1. classic delegate
    public delegate bool Chief(bool isFoodReady);
    public delegate string EatTheFood(string food);
    public delegate int PayForTheFood(int price);

    //1.2. generic delegate
    public delegate T Restaurant<T>(T arg);

    //1.3. action delegate
    public delegate void Action<in T1>(T1 arg1);
    public delegate void Action<in T1, in T2, in T3>(T1 arg1, T2 arg2, T3 arg3);


    //functions
    public static bool MakeFood(bool isFoodReady)
    {
        return isFoodReady;
    }

    public static string Consume(string food)
    {
        return $"I ate the {food}";
    }

    public static int Payment(int price)
    {
        return price;
    }

    public static string OrderFood(string foodName, int amount)
    {
        return $"{amount} {foodName} is ordered";
    }

    public static double PayForTheOrder(double price, int amount)
    {
        return price * amount;
    }

    public static void DeliveryRecieved(string foodName, int amount, int minutes)
    {
        Console.WriteLine($"{amount} {foodName} will be delivered to you in {minutes} minutes");
        Console.WriteLine("Delivery recieved!");
    }

    public static void SayThanksToDeliveryGuy(string name)
    {
        Console.WriteLine($"Thank you {name}!");
    }

    public static double TipTheDeliveryGuy()
    {
        return 2.45;
    }


    public static bool MyMethod(string name, int number)
    {
        if (name == "Mike" && number == 1)
        {
            return true;
        }

        return false;
    }
    public static void MyVoidMethod(string name, int number)
    {
        if (name == "Mike" && number == 1)
        {
            Console.WriteLine("Mike is number 1");
        }
        else
        {
            Console.WriteLine("Mike is not number 1");
        }
    }


    public static void Main()
    {
        //delegate implementation
        Chief chief = MakeFood;
        Console.WriteLine("The food is {0}", chief(true) ? "ready" : "is not ready yet");

        EatTheFood eatTheFood = Consume;
        Console.WriteLine(eatTheFood("T-Bone"));

        PayForTheFood payForTheFood = Payment;
        Console.WriteLine($"Total bill is {payForTheFood(20)}");

        //generic delegate implementation
        Restaurant<bool> genericChief = MakeFood;
        Restaurant<string> genericConsume = Consume;
        Restaurant<int> genericPayment = Payment;

        Console.WriteLine("The food is {0}", genericChief(true) ? "ready" : "is not ready yet");
        Console.WriteLine(genericConsume("T-Bone"));
        Console.WriteLine($"Total bill is {genericPayment(20)}");

        //1.4.func delegate
        //action & func delegate implementation
        Func<string, int, string> order = OrderFood;
        Func<string, int, bool> myDelegate = MyMethod;
        Action<string, int, int> delivery = DeliveryRecieved;
        Action<string> thanks = SayThanksToDeliveryGuy;
        Action<string,int> myVoidDelegate = MyVoidMethod;
        Func<double> tip = TipTheDeliveryGuy;
        Func<string, string> consume = Consume;

        Console.WriteLine(order("Mac Big", 2));
        delivery("Mac Big", 2, 10);
        thanks("Eddie");
        Console.WriteLine($"We tipped Eddie {tip()} dollars");
        Console.WriteLine(consume("Mac Big"));
        Console.WriteLine(myDelegate("Mike", 1)); 
        myVoidDelegate("Jane",1);

    }
}