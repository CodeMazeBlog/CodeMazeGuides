using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassStructOrRecordInCSharp
{
    public struct GeoLocation
    {
        private string _latitude;
        private string _longitude;

        public override string ToString() => $"(lat: {_latitude}, lon:{_longitude})";
    }
}
