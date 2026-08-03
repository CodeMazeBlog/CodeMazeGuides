namespace FlagsAttributeForEnum
{
    public static class UserTypeExtensionMethods
    {
        public static UserType Add(this UserType userType, params UserType[] typesToAdd)
        {
            foreach (var flag in typesToAdd)
            {
                userType |= flag;
            }

            return userType;
        }

        public static UserType Remove(this UserType userType, params UserType[] typesToRemove)
        {
            foreach (var item in typesToRemove)
            {
                userType &= ~item;
            }

            return userType;
        }

        public static bool CustomHasFlag(this UserType userType, UserType typeToCompare)
            => (userType & typeToCompare) == typeToCompare;

        public static void Print(this UserType userType)
            => Console.WriteLine("This message is for users of type: {0}.", userType);

    }
}
