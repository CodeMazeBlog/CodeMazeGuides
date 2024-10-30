using EarlyAndLateBinding;
using System.Reflection;

Console.WriteLine("Early Binding");
Animal animal = new Animal();
animal.Speak();

Console.WriteLine("Late Binding using dynamic keyword");
dynamic dynamicAnimal = new Animal();
dynamicAnimal.Speak();

Console.WriteLine("Late Binding using Reflection");
Type animalType = typeof(Animal);
object objectAnimal = Activator.CreateInstance(animalType)!;
MethodInfo speakMethod = animalType.GetMethod("Speak")!;
speakMethod?.Invoke(objectAnimal, null);