using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoXML
{
    public class Student
    {
        public string Name { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }

    public class Course
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Grade { get; set; }
        public int Credits { get; set; }
    }
}
