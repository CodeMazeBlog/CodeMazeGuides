// See https://aka.ms/new-console-template for more information

using ActionAndFuncDelegates;

var personList = (new PersonListProvider()).PersonList;

// update all defined person's age to increase +1 year 
personList.Update(IncrementAge);

// get age for all defined people
List<int> ages = personList.Map<int>(p => p.Age);


var verifyPerson = personList[0];
Console.WriteLine($"the age of {verifyPerson.FullName} is {verifyPerson.Age}.");

// get all People where age >= 30
var filteredList = personList.Filter(p => p.Age >= 30);
Console.WriteLine(filteredList.Count());


void IncrementAge(Person person)
{
    person.Age += 1;
}

Console.ReadLine();


