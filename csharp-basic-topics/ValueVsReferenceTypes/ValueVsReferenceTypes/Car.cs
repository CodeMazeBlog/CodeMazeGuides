namespace ValueVsReferenceTypes
{
    public class Car
    {
        private string carModelName="Toyota";
        public string CarModelName
        {
            get { return carModelName; }
            set { carModelName = value; }
        }
    }
}