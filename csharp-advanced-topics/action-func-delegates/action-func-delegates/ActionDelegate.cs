namespace action_func_delegates
{
    public static class ActionDelegate
    {
        public static void DisplayUsers(List<User> users, Action<User> display)
        {
            foreach (var user in users)
            {
                display(user);
            }
        }
    }
}
