namespace DependencyInjectionWithConstructorParameters
{
    public class DogSoundService : IDogSoundService
    {
        public string GetSound()
        {
            return "Woof";
        }
    }
}
