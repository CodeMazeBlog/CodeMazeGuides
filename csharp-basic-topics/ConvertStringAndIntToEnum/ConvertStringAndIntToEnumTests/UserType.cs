using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertStringAndIntToEnumTests
{
    [Flags]
    public enum UserType
    {
        None = 0,
        Customer = 1,
        Driver = 2,
        Admin = 4,
    }
}
