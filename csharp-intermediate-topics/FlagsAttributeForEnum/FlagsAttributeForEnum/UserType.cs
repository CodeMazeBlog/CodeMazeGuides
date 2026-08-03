namespace FlagsAttributeForEnum
{
    [Flags]
    public enum UserType
    {
        None = 0, //0b_0000
        Customer = 1, //0b_0001
        Driver = 2, //0b_0010
        Admin = 4, //0b_0100

        Employee = Driver | Admin //0b_0110
    }
}
