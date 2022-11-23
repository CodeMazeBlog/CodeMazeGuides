namespace ValueVsReferenceTypes
{
    public class Car
    {
        public string ChangeCarModel(CarModel car2)
        {
            car2.Model = "Nissan";

            return car2.Model;
        }
    }
}
