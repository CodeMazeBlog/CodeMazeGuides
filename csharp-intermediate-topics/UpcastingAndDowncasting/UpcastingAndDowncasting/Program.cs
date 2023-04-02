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

            foreach (var ani in animals)
            {
                Console.WriteLine("It says: " + ani.MakeSound());
            }

            //Downcasting
            Animal animal = new Snake();
            animal.MakeSound();
            ((Snake)animal).Move();

            if (animal is Snake)
            {
                var snake = (Snake)animal;
                snake.Move();
            }

            animal = new Owl();
            animal.MakeSound();

            EventHandler<AnimalEventArgs> animalEventHandler = (sender, args) =>
            {
                var owl = args.Animal as Owl;

                if (owl != null)
                {
                    owl.Fly();
                }
            };

            var eventArgs = new AnimalEventArgs() { Animal = animal };
            animalEventHandler(animal, eventArgs);

            var obj = new object();
            var owlObj = obj as Owl;

            if(owlObj != null)
            {
                owlObj.Fly();
            }
        }
    }
}