using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomHeaderResponse.Models
{
    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }
    }
}
