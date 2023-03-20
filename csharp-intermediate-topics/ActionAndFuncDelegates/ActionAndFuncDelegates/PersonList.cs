using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    public class PersonList
    {
        public readonly List<Person> _persons = new List<Person>();
        public PersonList()
        {
           
        }
        public Person this[int index]
        {
            get
            {
                return _persons[index];
            }
            set
            {
                _persons.Insert(index, value);
            }
        }

        public List<Person> Filter (Func<Person, bool> predicate)
        {
            return _persons.Where(predicate).ToList();
        }

        public List<T> Map<T>(Func<Person, T> mapper)
        {
            return _persons.Select(mapper).ToList();
        }

        public void Update(Action<Person> action) 
        {
            foreach (var item in _persons)
            {
                if(item != null)
                    action(item);
            }
        }
        ~PersonList()
        {
            Console.WriteLine("sdddddddddddddddddddddd");
        }
    }
}
