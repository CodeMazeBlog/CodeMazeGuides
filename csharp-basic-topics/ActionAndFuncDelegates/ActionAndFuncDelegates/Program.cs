using ActionAndFuncDelegates;

// different ways to assign Action delegate
void LocalFunction()
{
    Console.WriteLine("It's LocalFunction!");
}

Action a0 = LocalFunction;
Action a1 = MyClass.MyStaticMethod;
Action a2 = new MyClass().MyNonStaticMethod;
Action a3 = delegate ()
{
    Console.WriteLine("Its delegate function!");
};
Action a4 = () =>
{
    Console.WriteLine("Its lambda function!");
};

a0();
a1();
a2();
a3();
a4();

// contravariance
Action<Animal> animalAction = (Animal animal) => { animal.DoAnimalThing(); };
Action<Bear> bearAction = (Bear bear) => { bear.DoBearThing(); };

Console.WriteLine("Calling bearAction on Bear instance:");
bearAction(new Bear());

// this works
bearAction = animalAction;

Console.WriteLine("Calling bearAction which is actually animalAction nowm on Bear instance:");
bearAction(new Bear());

//uncomment to see that code below will not compile
//animalAction = bearAction;


// covariance
Func<Animal> animalFunc = () => new Animal();
Func<Bear> bearFunc = () => new Bear();


Console.WriteLine("Get animal from animalFunc:");
Animal animal = animalFunc();
Console.WriteLine($"Is this animal a bear?: {animal is Bear}");

// this works
animalFunc = bearFunc;

Console.WriteLine("Get animal from animalFunc which is actually bearFunc now, result:");
animal = animalFunc();
Console.WriteLine($"Is this animal a bear?: {animal is Bear}");

//uncomment to see that code below will not compile
//bearFunc = animalFunc;

// linq example
var numbers = Enumerable.Range(1, 100)
    .Where(i => i % 2 == 0) // Finc as predicate
    .Select(i => i * i) // Func as selector
    .OrderBy(i => -i) // Func as key selector
    .ToDictionary(i => i, i => new { Val = i })// Func key and element selector
    .ToList();

Console.WriteLine($"Numbers out: {string.Join("\n", numbers.Select(e => $"{e.Key}: {e.Value}"))}");