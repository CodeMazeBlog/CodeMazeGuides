using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DependencyInjectionWithConstructorParameters
{
    public class AnimalSoundService : IAnimalSoundService
    {
        public List<string> AnimalSounds { get; }

        public AnimalSoundService(IDogSoundService dogSoundService,
            IConfiguration configuration,
            IOptions<CowOptions> options,
            string sheepSound)
        {
            AnimalSounds = new List<string>()
            {
                dogSoundService.GetSound(),
                configuration["CatSound"],
                options.Value.CowSound,
                sheepSound
            };
        }

        public void Play()
        {
            foreach (var sound in AnimalSounds)
            {
                Console.WriteLine(sound);
            }
        }
    }
}
