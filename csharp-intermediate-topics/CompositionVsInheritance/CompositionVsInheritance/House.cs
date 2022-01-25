namespace CompositionVsInheritance
{
    public class House
    {
        public string Color { get; set; }

        public Ceiling ceiling = new Ceiling();
        public Floor floor = new Floor();

        public string GetCeiling()
        {
            return ceiling.BuildCeiling();
        }

        public string GetFloor()
        {
            return floor.BuildFloor();
        }

        //Moved to Address Component Class
        //public virtual string GetAddress()
        //{
        //    return "Address";
        //}
    }

    public class BrickHouse : House
    {
        public Address address = new Address();
        public string GetAddress()
        {
            return address.GetAddress();
        }
    }

    public class GlassHouse : House
    {
        public Address address = new Address();
        public string GetAddress()
        {
            return address.GetAddress();
        }

        public string WarningSign()
        {
            return "No rocks please!";
        }
    }

    public class Caravan : House
    {
        //No override needed after composition
        //public override string GetAddress()
        //{
        //    throw new Exception("No fixed address");
        //}
    }

    public class Address
    {
        public string GetAddress()
        {
            return "Address";
        }
    }

    public class Ceiling
    {
        public string BuildCeiling()
        {
            return "Building a ceiling...";
        }
    }

    public class Floor
    {
        public string BuildFloor()
        {
            return "Building a floor...";
        }
    }
}
