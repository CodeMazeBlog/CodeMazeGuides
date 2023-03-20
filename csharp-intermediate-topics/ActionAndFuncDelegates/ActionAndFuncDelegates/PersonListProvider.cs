using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates
{
    public class PersonListProvider
    {

        private readonly PersonList PersonList = new PersonList();
        public PersonListProvider()
        {
            // initialize list items
            PersonList[0] = new Person("Ahmed Elsayed", 25, 'M', null);
            PersonList[1] = new Person("Khaled Elsayed", 30, 'M', null);
            PersonList[2] = new Person("Maher saad", 35, 'M', null);
            
        }
    }
}
