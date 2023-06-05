using EntityFrameworkCoreVsDapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkCoreVsDapper.Repositories
{
    public interface IPersonsRepository
    {
        public List<Person> Get_1000_Persons();
        public List<Person> Get_10000_Persons();
        public List<Person> Get_100000_Persons();
    }
}
