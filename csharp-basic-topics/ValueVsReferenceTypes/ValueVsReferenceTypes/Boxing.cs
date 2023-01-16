using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueVsReferenceTypes
{
    public  class Boxing
    {
        public void BoxUnbox() {
            int carTyreCount = 4; 

            object boxedCarTyreCount = carTyreCount;

            int unBoxedCarTyreCount = (int)boxedCarTyreCount;
        }
    }
}
