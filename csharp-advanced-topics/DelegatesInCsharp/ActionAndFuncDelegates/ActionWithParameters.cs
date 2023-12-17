using ActionAndFuncDelegates.Entities;
using System;

namespace ActionAndFuncDelegates
{
    internal class ActionWithParameters
    {
        static void Main(string[] args)
        {
            // Action delegate with parameters
            Action<Person, Address> printPersonDetail = (p, a) => 
            {
                Console.WriteLine("Person details are:");
                Console.WriteLine($"Person Id: {p.PersonId}, \nName: {p.Name}, \nAge: {p.Age}, \nMobile: {p.MobileNo}");
                Console.WriteLine($"Address: {a.AddressLine1}, {a.City}, {a.Pincode}");
            };

            var person = new Person { PersonId = Guid.NewGuid(), Name = "John Eklund", Age = 34, MobileNo = "8787676567" };
            
            var address = new Address { AddressLine1 = "C2D-321, Long Street", City = "Pune", Pincode = 454343 };

            printPersonDetail.Invoke(person, address);            

            Console.ReadLine();
        }
    }
}
