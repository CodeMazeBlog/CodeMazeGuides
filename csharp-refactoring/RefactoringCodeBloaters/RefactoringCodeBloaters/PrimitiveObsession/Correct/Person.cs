using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_refactoring.PrimitiveObsession.Correct
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address? Address { get; private set; }

        public void AssignAddress(Address address)
        {
            Address = address;
        }
    }
}
