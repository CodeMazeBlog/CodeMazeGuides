using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_With_SQLite.DataModel
{
    public class Student
    {
        [Key] public int id { get; set; }
        public string name { get; set; }
        public string last_name { get; set; }
        public string faculty { get; set; }
        public string avg_GPA { get; set; }
    }
}
