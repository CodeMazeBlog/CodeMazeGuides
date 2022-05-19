using System;
using System.Collections.Generic;

namespace LINQBasicExample
{
    internal class StudentNameComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (string.Equals(x.StudentName, y.StudentName, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Student obj)
        {
            return obj.StudentName.GetHashCode();
        }
    }
}