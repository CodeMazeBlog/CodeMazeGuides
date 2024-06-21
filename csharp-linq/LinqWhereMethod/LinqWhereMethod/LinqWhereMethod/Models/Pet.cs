using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqWhereMethod.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Breed { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int PersonId { get; set; }
        public Person? Person { get; set; }
    }
}
