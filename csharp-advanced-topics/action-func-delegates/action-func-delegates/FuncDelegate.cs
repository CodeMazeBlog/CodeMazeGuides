namespace action_func_delegates
{
    public static class FuncDelegate
    {
        public static User Find(List<User> users, Func<User, bool> compare)
        {
            foreach (var user in users)
            {
                if (compare(user))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
