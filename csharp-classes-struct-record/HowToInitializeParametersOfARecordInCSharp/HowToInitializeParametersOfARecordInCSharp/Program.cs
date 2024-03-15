using HowToInitializeParametersOfARecordInCSharp;

var person = new Person("Joe", "Bloggs");
Console.WriteLine(person);

var person2 = new Person2("Joe", "Bloggs");
Console.WriteLine(person2);

var person3WithFriends = new Person3("Joe", "Bloggs", new List<string> { "Alice", "Bob" });
Console.WriteLine(person3WithFriends);
foreach (var friend in person3WithFriends.Friends)
    Console.WriteLine(friend);

var person3WithoutFriends = new Person3("Joe", "Bloggs");
Console.WriteLine(person3WithoutFriends);
foreach (var friend in person3WithoutFriends.Friends)
    Console.WriteLine(friend);

var person4WithFriends = new Person4("Joe", "Bloggs", new List<string> { "Alice", "Bob" });
Console.WriteLine(person4WithFriends);
foreach (var friend in person4WithFriends.Friends)
    Console.WriteLine(friend);

var person4WithoutFriends = new Person4("Joe", "Bloggs");
Console.WriteLine(person4WithoutFriends);
foreach (var friend in person4WithoutFriends.Friends)
    Console.WriteLine(friend);