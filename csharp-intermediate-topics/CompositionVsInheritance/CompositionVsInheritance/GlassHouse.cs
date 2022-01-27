namespace CompositionVsInheritance
{
    public class GlassHouse : House
    {
        private readonly Address _address;

        public GlassHouse()
        {
            _address = new Address();
        }

        public string GetAddress() => _address.GetAddress();

        public string WarningSign() => "No rocks please!";
    }
}
