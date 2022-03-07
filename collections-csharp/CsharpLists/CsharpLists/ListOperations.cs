using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpLists
{
    public class ListOperations
    {
        public List<string> AddElements() 
        {
            var countries = new List<string>();
            countries.Add("Mexico");
            countries.Add("Mexico");
            countries.Add("Italy");
            return countries;
        }
    }
}
