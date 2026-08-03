using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WritingCSV
{
    public class Person
    {
        [Name("Identifier")]
        [Index(0)]
        public int Id { get; set; }
        [Index(2)]
        public string Name { get; set; }
        [Index(1)]
        public bool IsLiving { get; set; }
        [Format("yyyy-MM-dd")]
        public DateTime DateOfBirth { get; set; }
    }
}
