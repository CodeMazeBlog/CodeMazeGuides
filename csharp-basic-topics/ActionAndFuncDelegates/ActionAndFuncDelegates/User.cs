namespace ActionAndFuncDelegates
{
    public class User
    {
        private Action<string, string> _listeners;
        private string Name { get; set; }
        private string Surname { get; set; }

        public void UpdateUserDetails(string name, string surname)
        {
            Name = name;
            Surname = surname;

            if (_listeners != null)
            {
                _listeners(Name, Surname);
            }
        }
        
        public void RegisterListener(Action<string, string> listener)
        {
            _listeners += listener;
        }
    }
}