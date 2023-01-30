namespace HowToCloneAList
{
    public class ToppingsList<T> : List<T>, ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
