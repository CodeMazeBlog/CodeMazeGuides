namespace GenericsInCSharp
{
    public class GenericArray<T>
    {
        private T[] _arrayObj;

        public GenericArray(int size)
        {
            _arrayObj = new T[size + 1];
        }

        public T RetrieveValue(int index)
        {
            return _arrayObj[index];
        }

        public void InsertValue(int index, T value)
        {
            _arrayObj[index] = value;
        }
    }
}
