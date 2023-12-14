using HowToInitializeParametersOfARecordInCSharp;

var person = new Person("Joe", "Bloggs");
Console.WriteLine(person);

var person2 = new Person2("Joe", "Bloggs");
Console.WriteLine(person2);

var person3 = new Person3("Joe", "Bloggs", new List<string> { "Alice", "Bob" });
Console.WriteLine(person3);
foreach (var friend in person3.Friends)
    Console.WriteLine(friend);

var person4 = new Person4("Joe", "Bloggs", new List<string> { "Alice", "Bob" });
Console.WriteLine(person4);
foreach (var friend in person4.Friends)
    Console.WriteLine(friend);