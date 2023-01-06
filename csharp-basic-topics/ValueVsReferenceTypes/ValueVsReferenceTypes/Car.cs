namespace ValueVsReferenceTypes
{
    public class Car
    {
        public Car(string modelName)=> ModelName = modelName;

        public string ChangeCarModel(string newModel)
        {
            ModelName = newModel;
            return ModelName;
        }

        public string ModelName { get; set; }
    }
}