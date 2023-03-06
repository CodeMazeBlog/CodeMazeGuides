// See https://aka.ms/new-console-template for more information

using ActionAndFuncDelegates;

// initialize list items
PersonList personList = new PersonList();
personList[0] = new Person("Ahmed Elsayed", 25, 'M', null);
personList[1] = new Person("khaled Elsayed", 30, 'M', null);
personList[2] = new Person("Maher saad", 35, 'M', null);

// update all defined person age to increase +1 year 
personList.Update(IncrementAge);
void IncrementAge(Person person)
{
    person.Age += 1;
}
var verifyPerson = personList[0];
Console.WriteLine($"the age of {verifyPerson.FullName} is {verifyPerson.Age}.");

// get all People where age >= 30
var filteredList = personList.Filter(p => p.Age >= 30);
Console.WriteLine(filteredList.Count());

// get age for all defined people
List<int> ages = personList.Map<int>(p => p.Age);
Console.ReadLine();