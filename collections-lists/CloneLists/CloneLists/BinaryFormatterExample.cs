using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CloneLists
{
    public class BinaryFormatterExample
    {
        public List<Resort>? clonedResortList; 
        public void RunBinaryFormatterExample(List<Resort> rlist)
        {
            clonedResortList = rlist.GetClone();
        }
    }

    public static class Ext
    {
        public static List<T> GetClone<T>(this List<T> list)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, list);
            stream.Position = 0;
            return (List<T>)formatter.Deserialize(stream);
        }
    }

}
