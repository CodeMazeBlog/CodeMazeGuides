namespace UpcastingAndDowncasting
{
    public class AnimalEventArgs : EventArgs
    {
        public required Animal Animal { get; set; }
    }
}
