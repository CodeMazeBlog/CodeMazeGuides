//Code for Abstraction
Animal dog = new Dog();
dog.Name = "Buddy";
dog.Age = 3;
Console.WriteLine($"{dog.Name} says:");
dog.MakeSound();

Animal cat = new Cat();
cat.Name = "Whiskers";
cat.Age = 2;
Console.WriteLine($"{cat.Name} says:");
cat.MakeSound();

Console.WriteLine($"\n--------------------\n");

//Code for Encapsulation 
BankAccount account = new BankAccount("1234567890");

account.Deposit(500);
account.Withdraw(200);

Console.WriteLine($"Final Account Information - Account Number: {account.AccountNumber}, Balance: {account.Balance}");