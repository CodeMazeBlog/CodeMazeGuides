using System;

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
