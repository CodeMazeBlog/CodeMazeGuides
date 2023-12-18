using ActionAndFuncDelegate.Entities;

namespace ActionAndFuncDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Action delegate without parameters:");
            Action printInformation = () =>
            {
                Console.WriteLine("It prints without parameter");
            };
            printInformation();

            Console.WriteLine("\nAction delegate with parameters:");
            Action<Person, Address> printPersonDetail = (p, a) =>
            {
                Console.WriteLine("Person details are:");
                Console.WriteLine($"Person Id: {p.PersonId}, \nName: {p.Name}, \nAge: {p.Age}, \nMobile: {p.MobileNo}");
                Console.WriteLine($"Address: {a.AddressLine1}, {a.City}, {a.Pincode}");
            };

            var person = new Person { PersonId = Guid.NewGuid(), Name = "John Eklund", Age = 34, MobileNo = "8787676567" };
            var address = new Address { AddressLine1 = "C2D-321, Long Street", City = "Pune", Pincode = 454343 };
            printPersonDetail.Invoke(person, address);

            Console.WriteLine("\nFunc delegate with one parameter and return value:");
            Func<int, int> Square = a => a * a;
            Console.WriteLine($"Area of Square is: {Square(4)}");

            Console.WriteLine("\nFunc delegate with two parameters and return value:");
            Func<int, int, int> Rectangle = (a, b) => a * b;
            Console.WriteLine($"Area of Rectangle is: {Rectangle(4, 3)}");

            Console.WriteLine("\nFunc delegate without lambda expression:");
            Func<int, bool> isEvenNo = a => CheckEvenNo(a);
            Console.WriteLine($"Is {5} an even no? {isEvenNo(5)}");
            
            Console.ReadLine();
        }

        private static bool CheckEvenNo(int a)
        {
            return a % 2 == 0;
        }
    }
}
