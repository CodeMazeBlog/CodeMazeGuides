namespace UpcastingAndDowncasting
{
    public class Snake : Animal
    {
        public override string MakeSound()
        {
            return "Hiss";
        }

        public string Move()
        {
            return "Slithering...";
        }
    }
}
