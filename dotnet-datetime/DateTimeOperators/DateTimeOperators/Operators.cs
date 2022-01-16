using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeOperators
{
    public class Operators
    {

        public DateTime AddOperation(DateTime dt, TimeSpan ts) 
        {
            DateTime result = dt.Add(ts);
            return result;
        }

        public DateTime SubtractOperation(DateTime dt, TimeSpan ts) 
        {
            DateTime result = dt.Subtract(ts);
            return result;
        }

        public TimeSpan SubtractOperation(DateTime dt, DateTime dt1)
        {
            TimeSpan result = dt.Subtract(dt1);
            return result;
        }

        public bool EqualityOperation(DateTime dt, DateTime dt1) 
        {
            return dt.Equals(dt1);
        }

        public bool InequalityOperation(DateTime dt, DateTime dt1) 
        {
            return dt != dt1;
        }

        public int CompareDates(DateTime dt, DateTime dt1) 
        {
            return dt.CompareTo(dt1);
        }

        public bool GreaterThanOperation(DateTime dt, DateTime dt1)
        {
            return dt > dt1;
        }

        public bool GreaterThanOrEqualOperation(DateTime dt, DateTime dt1)
        {
            return dt >= dt1;
        }

        public bool LessThanOperation(DateTime dt, DateTime dt1)
        {
            return dt < dt1;
        }

        public bool LessThanOrEqualOperation(DateTime dt, DateTime dt1)
        {
            return dt <= dt1;
        }
    }
}
