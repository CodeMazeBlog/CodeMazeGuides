
namespace GenerateRandom
{
    public class RandomCustom : Random
    {
        protected override double Sample()
        {
            return ModifySample(base.Sample());
        }

        private static double ModifySample(double sample)
        {
            double newSample = Math.Log(sample);
            return newSample;
        }

        public override int Next()
        {
            return (int)(Sample() * int.MaxValue);
        }
    }
}
