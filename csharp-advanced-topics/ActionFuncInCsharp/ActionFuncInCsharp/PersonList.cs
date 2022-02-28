using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncInCsharp
{
    public class PersonList : List<Person>
    {
        public PersonList()
        {
            Add(new() { Name = "Murat", Lastname = "Yuceer" });
            Add(new() { Name = "Code", Lastname = "Maze" });
            Add(new() { Name = "Vladimir", Lastname = "Pecanac" });
        }
    }
    public class Person
    {
        public string? Name { get; init; }
        public string? Lastname { get; init; }
    }
}
