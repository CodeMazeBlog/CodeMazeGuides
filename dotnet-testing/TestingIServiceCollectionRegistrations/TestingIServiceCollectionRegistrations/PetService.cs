namespace TestingIServiceCollectionRegistrations;

public class PetService : IAnimalService
{
    public void PrintName(string name)
    {
        Console.WriteLine("The name of the pet is {0}",name);
    }
}