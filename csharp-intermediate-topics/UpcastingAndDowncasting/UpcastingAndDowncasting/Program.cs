namespace UpcastingAndDowncasting
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Upcasting
            var animals = new List<Animal>
            {
                new Snake(),
                new Owl()
            };

            foreach (var animalObj in animals)
            {
                Console.WriteLine("It says: " + animalObj.MakeSound());
            }

            //Downcasting
            Animal animal = new Snake();
            animal.MakeSound();
            ((Snake)animal).Move();

            if (animal is Snake snake)
            {
                snake.Move();
            }

            animal = new Owl();
            animal.MakeSound();

            EventHandler<AnimalEventArgs> animalEventHandler = (sender, args) =>
            {
                if (args.Animal is Owl owl)
                {
                    owl.Fly();
                }
            };

            var eventArgs = new AnimalEventArgs() { Animal = animal };
            animalEventHandler(animal, eventArgs);

            var obj = new object();
            var owlObj = obj as Owl;

            if (owlObj != null)
            {
                owlObj.Fly();
            }
        }
    }
}