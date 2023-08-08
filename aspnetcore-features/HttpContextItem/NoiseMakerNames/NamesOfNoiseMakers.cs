namespace NoiseMakerNames
{
    public class NamesOfNoiseMakers
    {
        private readonly List<NoiseMaker> _noiseMakers = new List<NoiseMaker>()
        {
           new NoiseMaker()
           {
               Name = "Sheldon Cooper",
               Severity = 5,
               FirstAppearance = false
           },
           new NoiseMaker()
           {
               Name = "Raj Koothrapalli",
               Severity = 1,
               FirstAppearance = true
           },
           new NoiseMaker()
           {
               Name = "Howard Wolowitz",
               Severity = 3,
               FirstAppearance = false
           }
        };

        public void AddNoiseMaker(NoiseMaker noiseMaker)
        {
            _noiseMakers.Add(noiseMaker);
        }

        public List<NoiseMaker> GetNoiseMakers()
        {
            return _noiseMakers;
        }
    }
}
