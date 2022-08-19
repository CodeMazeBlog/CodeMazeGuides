namespace GenericsInCSharp
{
    public class GenericArray<T>
    {
        private T[] arrayObj;
        public GenericArray(int size)
        {
            arrayObj = new T[size + 1];
        }
        public T retrieveValue(int index)
        {
            return arrayObj[index];
        }
        public void insertValue(int index, T value)
        {
            arrayObj[index] = value;
        }
    }
}
