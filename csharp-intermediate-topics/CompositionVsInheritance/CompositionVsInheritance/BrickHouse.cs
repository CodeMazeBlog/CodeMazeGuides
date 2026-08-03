namespace CompositionVsInheritance
{
    public class BrickHouse : House
    {
        private readonly Address _address;

        public BrickHouse()
        {
            _address = new Address();
        }

        public string GetAddress() => _address.GetAddress();
    }
}
