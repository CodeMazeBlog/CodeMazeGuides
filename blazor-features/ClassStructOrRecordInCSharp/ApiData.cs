using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassStructOrRecordInCSharp
{
    public record ApiData
    {
        public int Id { get; set; }
    }

    public record OtherApiData(string id);
}
