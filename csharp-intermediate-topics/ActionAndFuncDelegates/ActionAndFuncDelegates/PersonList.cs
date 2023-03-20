using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    public class PersonList
    {
        private readonly List<Person> _persons = new List<Person>();
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
            _persons.ForEach(action);
        }
    }
}
