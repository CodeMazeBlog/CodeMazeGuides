namespace ValueAndReferenceTypes
{
    public class BoxingAndUnboxing
    {
        public int BoxingUnBoxing(int intType)
        {
            object obj = intType;            
            int objToInt = (int)obj;

            return objToInt;
        }
    }
}
