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
        public string latitude;
        public string longitude;

        public override string ToString() => $"(lat: {latitude}, lon:{longitude})";
    }
}
