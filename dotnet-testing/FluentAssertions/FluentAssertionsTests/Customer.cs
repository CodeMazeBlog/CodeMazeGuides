using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentAssertionsTests
{
    public class Customer
    {
        public Customer(int id)
        {
            Id = id;
        }

        public Customer() { }

        public int? Id { get; set; }

        public int GetId()
        {
            if (Id is null)
            {
                throw new NullReferenceException();
            }

            return Id ?? -1;
        }

        public async Task<int> GetIdAsync()
        {
            return await Task.FromResult(GetId());
        }
    }
}
