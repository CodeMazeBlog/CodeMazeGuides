namespace ActionAndFuncDelegates
{
    public class User
    {
        private Action<string, string> _listeners;
        private string _name;
        private string _surname;

        public void UpdateUserDetails(string name, string surname)
        {
            _name = name;
            _surname = surname;

            if (_listeners != null)
            {
                _listeners(_name, _surname);
            }
        }
        
        public void RegisterListener(Action<string, string> listener)
        {
            _listeners += listener;
        }
    }
}