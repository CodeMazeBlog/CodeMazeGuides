namespace CompositionVsInheritance
{
    public class House
    {
        private readonly Ceiling _ceiling;
        private readonly Floor _floor;
        public string Color { get; set; }

        public House()
        {
            _ceiling = new Ceiling();
            _floor = new Floor();
        }

        public string GetCeiling() => _ceiling.BuildCeiling();

        public string GetFloor() => _floor.BuildFloor();
    }
}
