namespace TestingExceptions
{
    public class Hero
    {
        private const int ExperienceNeeded = 1000;

        public int Level { get; set; }
        public int Experience { get; set; }

        public Hero(int experience)
        {
            Level = 0;
            Experience = experience;
        }

        public void LevelUp()
        {
            if (Experience - ExperienceNeeded < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(Experience),
                    "Not enough Experience to level up!");
            }

            Experience -= ExperienceNeeded;
            Level++;
        }

        public async Task LevelUpAsync()
        {
            if (Experience - ExperienceNeeded < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(Experience),
                    "Not enough Experience to level up asynchronously!");
            }

            Experience -= ExperienceNeeded;
            Level++;

            await Task.CompletedTask;
        }
    }
}
