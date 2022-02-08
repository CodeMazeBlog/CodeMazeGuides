using System;

namespace CustomCollectionTests
{
    /// <summary>
    /// A silly class used to demonstrate our collection.
    /// </summary>
    public class MyInteger : IComparable<MyInteger>
    {
        public MyInteger()
        {
        }

        public MyInteger(int value)
        {
            Value = value;
        }

        /// <summary>
        /// The basic value that is stored in the class.
        /// </summary>
        public int Value { get; set; }

        public int CompareTo(MyInteger? other)
        {
            if (other != null)
            {
                return Value - other.Value;
            }

            throw new ArgumentNullException(nameof(other));
        }
    }
}