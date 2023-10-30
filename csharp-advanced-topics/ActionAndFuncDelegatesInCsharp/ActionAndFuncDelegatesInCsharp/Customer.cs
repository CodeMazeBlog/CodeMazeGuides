namespace ActionAndFuncDelegatesInCsharp;


public class Customer
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string ShirtSize { get; set; }

    public Customer(string Name, int Age, string ShirtSize)
    {
        this.Name = Name;
        this.Age = Age;
        this.ShirtSize = "L";
    }

}