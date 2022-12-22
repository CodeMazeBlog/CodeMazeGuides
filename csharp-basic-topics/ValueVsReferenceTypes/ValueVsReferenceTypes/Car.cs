namespace ValueVsReferenceTypes
{
    public class Car
    {
        public string ChangeCarModel( string newModel)
        {
            ModelName = newModel;
            return ModelName;
        }

        public string? ModelName { get; set; }
    }
}