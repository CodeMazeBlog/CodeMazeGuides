namespace ConstructorOverloadingInCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var animal = new Animal("Tom", "cat", 82);

            var copyAnimal = new Animal(animal);

            Console.WriteLine(String.Format(" Name: {0} \n Type: {1} \n Age: {2}", copyAnimal.Name, copyAnimal.Type, copyAnimal.Age));

            Console.ReadKey();
        }
    }
}